using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class MufinSpawner : MonoBehaviour
{

    public float _speedSpawn = 3f;
    public float _delayTime = 2f;

    public GameObject Muffin;
    Vector3 pos = new Vector3(-13, 3.6f, 0);

    // Start is called before the first frame update
    void Start()
    {
        //Staring from 5 sec every 5 sec
        InvokeRepeating("Spawn",5f,5f);

    }

    private void Update()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        
    }

    void Spawn()
    {
        Instantiate(Muffin,pos,Quaternion.identity);
    }

}
