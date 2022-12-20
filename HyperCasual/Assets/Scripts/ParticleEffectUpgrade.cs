using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ParticleEffectUpgrade : MonoBehaviour
{
    public GameObject particleGameObject;

    private ParticleSystem[] allParticles;
    private ParticleSystem particle;

    int particleNumber;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Muffin")
        {
            //Debug.Log("triggered!");
            particleGameObject = GameObject.FindGameObjectWithTag("UpgradeParticle");
           // Debug.Log("ParticleGameobjectname: " + particleGameObject.name);
            particleGameObject.transform.position = this.transform.position;
           // Debug.Log("particle pos: " + particleGameObject.transform.position);
            particleNumber = other.GetComponent<MufinController>().random_number;
           // Debug.Log("Particle number: " + particleNumber);
            allParticles = particleGameObject.transform.GetChild(particleNumber).GetComponentsInChildren<ParticleSystem>();//.GetComponents<ParticleSystem>();
            foreach (ParticleSystem pr in allParticles)
            {
                pr.Play();
            }
        }
    }


}
