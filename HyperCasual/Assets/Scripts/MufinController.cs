using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MufinController: MonoBehaviour
{
    Vector3 _transform_target;
    public float _speed = 5f;
    private bool isWaiting = false;

    [SerializeField] public float [] x_positons;

    int position_counter = 1;
    private void Start()
    {
        //Start - > transition to postion;
        _transform_target.x = x_positons[position_counter];
        position_counter++;
    }

    private void Update()
    {
        if (!isWaiting) 
        {
            if (transform.position.x <= _transform_target.x)
            {
                
                //Vector based     
                transform.position = new Vector3(this.transform.position.x + 0.1f*_speed, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                StartCoroutine(Wait());        
            }
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true; 
        print("Start to wait");
        _transform_target.x =x_positons[position_counter];
        position_counter++;
        yield return new WaitForSeconds(2); 
        print("Wait complete");
        isWaiting = false; 
    }



}
