using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] public GameObject[] _tracks;

    public int numberOfUpgrade = 0;
    public int numberAddedTracks = 0;

    public GameObject track;
    public static float track_seperation = 0f;

    public bool isUpgraded = false;
    void Start()
    {
        track_seperation = 7f;
        _tracks[numberOfUpgrade].SetActive(true);
    }

    public void AddTrack()
    {
        Instantiate(track, new Vector3(track.transform.position.x, track.transform.position.y, track.transform.position.z + track_seperation), Quaternion.identity);
        track_seperation += 7f;
    }

    public void UpdateIndex()
    {
        GameObject[] alltracks = GameObject.FindGameObjectsWithTag("track");

        foreach (GameObject track in alltracks)
        {
            track.transform.GetChild(numberOfUpgrade).gameObject.SetActive(false);
        }

    }
}
