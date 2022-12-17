using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCheck : MonoBehaviour
{


    public GameObject upgradeUnit1;

   // private ParticleSystem[] particleSystems;

    void Start()
    {
       //
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(upgradeUnit1);
        }
    }
}
