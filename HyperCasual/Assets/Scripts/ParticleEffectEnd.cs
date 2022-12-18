using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ParticleEffectEnd : MonoBehaviour
{
    public GameObject particleGameObject;

    private ParticleSystem[] allParticles;
    private ParticleSystem particle;

    int particleNumber;

  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered!");
        particleGameObject = GameObject.FindGameObjectWithTag("EndParticleEffects");
        particleGameObject.transform.position = this.transform.position;
        particleNumber = other.GetComponent<MufinController>().random_number;
        allParticles = particleGameObject.transform.GetChild(particleNumber).GetComponentsInChildren<ParticleSystem>();//.GetComponents<ParticleSystem>();
        foreach (ParticleSystem pr in allParticles)
       {
          pr.Play();
        }
        
    }

    
}
