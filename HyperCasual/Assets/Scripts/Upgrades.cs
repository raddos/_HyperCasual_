using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Upgrades:MonoBehaviour
{
    private GameObject[] trackGameObjects;

    public Track _track;


    public static float track_speed = 1f;
    public static float spawn_time = 2.5f;
    public static float waiting_time = 2f;

    public void UpdateTrackSpeed(float multiplier)
    {
            track_speed += multiplier;
    }

    public void UpdateSpawnTime(float number)
    {
     //   Debug.Log("begore - " + spawn_time);
        spawn_time -= number;
       // Debug.Log("AFter - " + spawn_time);

    }

    public void UpdateWaitingTime(float number)
    {

       waiting_time-= number;

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
