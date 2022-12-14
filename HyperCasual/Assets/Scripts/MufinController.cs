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
    public float _speed = 1f;
    public float _timePouseOnTrack = 2f;
    private bool isWaiting = false;
    GameObject _gameObject;


    [SerializeField] public float [] x_positons;

    int position_counter = 1;
    private void Start()
    {
        //Start - > transition to postion;
        //Animator to do 
        _transform_target.x = x_positons[position_counter];
        _gameObject = this.gameObject;
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
                if (position_counter <= 7)
                    StartCoroutine(Wait());
                else
                    StartCoroutine(End());
            }

        }
    }

    IEnumerator Wait()
    {
        isWaiting = true; 
        print("Start to wait");  
       _transform_target.x = x_positons[position_counter];
        //Can add specific sounds on different stations here

        position_counter++;
        yield return new WaitForSeconds(_timePouseOnTrack); 
        print("Wait complete");
        isWaiting = false;
    }

    IEnumerator End()
    {
        if (position_counter >= 7)
        {
            //Animation
            
            //Add music
            
            //Add to hud score/money
            UIManager.Instance.Score();
            //Destory
            Destroy(gameObject);

        }
        yield return null;
    }

}
