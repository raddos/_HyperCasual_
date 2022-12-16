using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MufinSpawner : MonoBehaviour
{
    [Header("Speed of Spawner")]
    [SerializeField] public float _speedSpawn = 5f;
 
    //this-> Muffin Controller 
    public GameObject Muffin;

    Vector3 spawn_position = new Vector3(-13, 3.6f, 0);
    Vector3 second_position = new Vector3(-9.5f, 3.6f, 0);
    // Start is called before the first frame update


  
    void Start()
    {
        //Staring from 5 sec every 5 sec
        InvokeRepeating("Spawn",_speedSpawn,10f);

    }

    private void Update()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        if (Input.GetMouseButtonDown(0))
        {
            //if UI is not over screen
            if (!IsPointerOverUIObject())
            {
                if (!isOccupied())
                {

                    Instantiate(Muffin);
                }
            }

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



    void Spawn()
    {
        if (!isOccupied())
        {
            Instantiate(Muffin, spawn_position, Quaternion.identity);
        }
        
    }

    bool isOccupied()
    {
        //Spawn location and second location must be different
        return Physics.CheckBox(spawn_position, Muffin.transform.localScale) || Physics.CheckBox(second_position, Muffin.transform.localScale);
    }
}
