using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckRenderingPipeline : MonoBehaviour
{
   
    void Start()
    {
        Debug.Log(UniversalRenderPipeline.asset.name);
    }

    
}
