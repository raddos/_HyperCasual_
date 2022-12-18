using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MufinSpawner : MonoBehaviour
{
    [Header("Speed of Spawner")]
    [SerializeField] public float _speedSpawn;
    //this-> Muffin Controller 
    public GameObject _muffin;

    //track 1
    Vector3 spawn_position_track1;
    Vector3 second_position_track1;
    //track 2
    Vector3 spawn_position_track2;
    Vector3 second_position_track2;
    //track 3
    Vector3 spawn_position_track3;
    Vector3 second_position_track3;
    //track 4
    Vector3 spawn_position_track4;
    Vector3 second_position_track4;
    //track 5
    Vector3 spawn_position_track5;
    Vector3 second_position_track5;

    private bool isSpawning = true;

    //button option
    private Upgrades upg;
    //
    //Vector3 spawn_position_track2 = new (spawn_position_track1.x, spawn_position_track1.y, spawn_position_track1.z + 5f);

    private Track _track;
  
    void Start()
    {

        upg = GameObject.FindGameObjectWithTag("Upgrade").GetComponent<Upgrades>();
        _speedSpawn = Upgrades.spawn_time;
        //1
        spawn_position_track1 = new Vector3(-13, 3.6f, 0);
        second_position_track1 = new Vector3(-9.5f, 3.6f, 0);
        //2
        spawn_position_track2= new Vector3(-13, 3.6f, 5f);
        second_position_track2 = new Vector3(-9.5f, 3.6f, 5f);
        //3
        spawn_position_track3 = new Vector3(-13, 3.6f, 10f);
        second_position_track3 = new Vector3(-9.5f, 3.6f, 10f);
        //4
        spawn_position_track4 = new Vector3(-13, 3.6f, 15f);
        second_position_track4 = new Vector3(-9.5f, 3.6f, 15f);
        //5
        spawn_position_track5 = new Vector3(-13, 3.6f, 20f);
        second_position_track5 = new Vector3(-9.5f, 3.6f, 20f);
        _track = GetComponent<Track>();
        //Staring from 5 sec every 5 sec :_speedSpawn;
        //Spawn every 10 seoconds 
        //Fix-> not as enumerator
        //InvokeRepeating("Spawn",_speedSpawn,10f);
        StartCoroutine(Spawn());

    }

    private void Update()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        if (Input.GetMouseButtonDown(0))
        {
            //if UI is not over screen
            if (!IsPointerOverUIObject())
            {
                Debug.Log(_speedSpawn);
                StartCoroutine(SpawnMuffin()); 
            }

        }

        //Spawn time speed 
        if (UIManager.Instance.isSpawnTimeUpdate)
        {
             upg.UpdateSpawnTime(0.05f);
            _speedSpawn = Upgrades.spawn_time;

            UIManager.Instance.isSpawnTimeUpdate= false;
        }
    }


    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, raycastResults);
        return raycastResults.Count > 1;
    }



    IEnumerator Spawn()
    {
        while (isSpawning)
        {
            if (!isOccupied())
            {
                //0
                Instantiate(_muffin, spawn_position_track1, Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);

            }

            if (!isOccupiedTrack2() && _track.numberAddedTracks > 0)
            {
                Instantiate(_muffin, new Vector3(spawn_position_track2.x, 3.6f, spawn_position_track2.z), Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }
            if (!isOccupiedTrack3() && _track.numberAddedTracks > 1)
            {
                Instantiate(_muffin, new Vector3(spawn_position_track3.x, 3.6f, spawn_position_track3.z), Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }
            if (!isOccupiedTrack4() && _track.numberAddedTracks > 2)
            {
                Instantiate(_muffin, new Vector3(spawn_position_track4.x, 3.6f, spawn_position_track4.z), Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }
            if (!isOccupiedTrack5() && _track.numberAddedTracks > 3)
            {
                Instantiate(_muffin, new Vector3(spawn_position_track5.x, 3.6f, spawn_position_track5.z), Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }
            yield return new WaitForSeconds(_speedSpawn);
        }
    }

    bool isOccupied()
    {
        //Spawn location and second location must be different
        return Physics.CheckBox(spawn_position_track1, _muffin.transform.localScale) || Physics.CheckBox(second_position_track1, _muffin.transform.localScale);
    }
    //function for every track 
    bool isOccupiedTrack2()
    {
        return Physics.CheckBox(spawn_position_track2, _muffin.transform.localScale) || Physics.CheckBox(second_position_track2, _muffin.transform.localScale);

    }
    bool isOccupiedTrack3()
    {
        return Physics.CheckBox(spawn_position_track3, _muffin.transform.localScale) || Physics.CheckBox(second_position_track3, _muffin.transform.localScale);

    }
    bool isOccupiedTrack4()
    {
        return Physics.CheckBox(spawn_position_track4, _muffin.transform.localScale) || Physics.CheckBox(second_position_track4, _muffin.transform.localScale);

    }
    bool isOccupiedTrack5()
    {
        return Physics.CheckBox(spawn_position_track5, _muffin.transform.localScale) || Physics.CheckBox(second_position_track5, _muffin.transform.localScale);

    }



    private IEnumerator SpawnMuffin()
    {
        //First track
        if (!isOccupied())
        {
            Debug.Log("not occupied");
            Instantiate(_muffin);
            yield return null;
        }
        if (_track.numberAddedTracks > 0)
        {
            //Second track
            if (!isOccupiedTrack2())
            {
                Instantiate(_muffin, spawn_position_track2, Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }
        }

        if (_track.numberAddedTracks > 1)
        {
            //Third track
            if (!isOccupiedTrack3())
            {

                Instantiate(_muffin, spawn_position_track3, Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }
        }

        if (_track.numberAddedTracks > 2)
        {
            //Fourth track
            if (!isOccupiedTrack4())
            {

                Instantiate(_muffin, spawn_position_track4, Quaternion.identity);
                yield return new WaitForSeconds(_speedSpawn);
            }

        }
        if (_track.numberAddedTracks > 3)
        {
            //Fifth track
            if (!isOccupiedTrack4())
            {

                Instantiate(_muffin, spawn_position_track5, Quaternion.identity);
            }

        }
    }
}
