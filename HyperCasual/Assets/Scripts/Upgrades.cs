using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Upgrades:MonoBehaviour
{
    private GameObject[] trackGameObjects;

    public static float track_speed = 1f;

    public Track _track;

    public static float spawn_time = 1f;

    public void UpdateTrackSpeed(int multiplier)
    {
       track_speed *= multiplier;
    }

    public void UpdateSpawnTime(int number_mult)
    {
        spawn_time += number_mult; 
    }

    private void Start()
    {
    }

    private void Update()
    {
        if(_track.numberOfUpgrade == 1)
        {
            SetFirstUpgrade();
        }

        if(_track.numberOfUpgrade == 2)
        {
            SetSecondUpgrade();
        }
    }

    void SetFirstUpgrade()
    {
        trackGameObjects = GameObject.FindGameObjectsWithTag("TrackGameObject");
        foreach(GameObject track in trackGameObjects)
         {
            
                track.transform.GetChild(0).gameObject.SetActive(false);
            
        }
        trackGameObjects = GameObject.FindGameObjectsWithTag("TrackGameObject");
        foreach (GameObject track in trackGameObjects)
        {             
                track.transform.GetChild(1).gameObject.SetActive(true); 
        }

    }

    void SetSecondUpgrade()
    {
        trackGameObjects = GameObject.FindGameObjectsWithTag("TrackGameObject");
        foreach (GameObject track in trackGameObjects)
        {

            track.transform.GetChild(1).gameObject.SetActive(false);

        }
        trackGameObjects = GameObject.FindGameObjectsWithTag("TrackGameObject");
        foreach (GameObject track in trackGameObjects)
        {
            track.transform.GetChild(2).gameObject.SetActive(true);
        }

    }
}
