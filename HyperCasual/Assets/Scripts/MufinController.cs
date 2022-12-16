using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class MufinController: MonoBehaviour
{
    Vector3 _transform_target;
    public float _speed = 5f;
    public float _timePouseOnTrack = 2f;
    private bool isWaiting = false;

    [SerializeField] public float [] x_positons;
    
    [SerializeField] Muffin _muffin;
    private GameObject muffin;

    GameObject[] mesh_list;


    [SerializeField] public Upgrades upg;


    int position_counter = 1;
    int mesh_num = 0;
    int random_number;

    private void Awake()
    {
        _speed = Upgrades.track_speed;
        upg=GetComponent<Upgrades>();
        random_number = UnityEngine.Random.Range(0, 5);
        mesh_list = _muffin.returnMuffinChildren(random_number);
        muffin = _muffin.returnMuffin(random_number);


        //Check track number
        //if more then 2 add meus
    }

    private void Start()
    {
        _transform_target.x = x_positons[position_counter];
        //Start - > transition to postion;
        //Animator to do 
        muffin.SetActive(true);
        mesh_list[mesh_num].SetActive(true);
           
        position_counter++;
        mesh_num++;
    }

    private void Update()
    {


        //Update speed 
        if (UIManager.Instance.isTrackSpeedUpdated)
        {
            upg.UpdateTrackSpeed(10);

            UIManager.Instance.isTrackSpeedUpdated = false;
        }

        //Muffin movement
        if (!isWaiting)
        {
            if (transform.position.x <= _transform_target.x)
            { 
                //Vector based     
                transform.position = new Vector3(this.transform.position.x + 0.1f*_speed, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                if (position_counter <= 5)
                    StartCoroutine(Wait());
                else
                    StartCoroutine(End());
            }

        }
    }

    
    
    IEnumerator Wait()
    {
        isWaiting = true;
        //print("Start to wait");  
        _transform_target.x = x_positons[position_counter];
        //Can add specific sounds on different stations here


        if (mesh_num < mesh_list.Length )
        {
        mesh_list[mesh_num].SetActive(true);
        mesh_num++;
         }   
        position_counter++;
        yield return new WaitForSeconds(_timePouseOnTrack); 
        //print("Wait complete");
        isWaiting = false;
    }

    IEnumerator End()
    {
        if (position_counter >= 5)
        {
            //Animation
            
            //Add music
            
            //Add to hud score/money
            UIManager.Instance.IncreaseScore();
            //Destory
            Destroy(gameObject);

        }
        yield return null;
    }



    public void SetMuffinNumber()
    {
        //Transfrom target - > positions
        

    }








}
