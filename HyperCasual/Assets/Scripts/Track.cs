using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] public GameObject[] _tracks;

    //this numbers goes to -> muffin controller
    private int random_number;

    private void Awake()
    {
        random_number=Random.Range(0, _tracks.Length); 
    }
    void Start()
    {
        _tracks[random_number].SetActive(true);
    }

    public int GetTrackNumber()
    {
        return random_number;
    }
}
