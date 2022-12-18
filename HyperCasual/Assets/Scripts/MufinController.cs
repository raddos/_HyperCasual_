using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class MufinController: MonoBehaviour
{
    Vector3 _transform_target;
    public float _speed = 5f;
    public float _waitingTime = 2f;
    private bool isWaiting = false;

    [SerializeField] public float [] x_positons;
    
   
    private Track track;
    private GameObject trackGameObject;

    //First muffin
    [SerializeField] Muffin _muffin;
    private GameObject muffin;
    GameObject[] mesh_list;



    //Second muffin
    [SerializeField] Muffin _muffin_copy;
    GameObject[] mesh_list_copy;
    GameObject muffin_copy;


    //Third muffin
    [SerializeField] Muffin _muffin_copy2;
    GameObject[] mesh_list_copy2;
    GameObject muffin_copy2;


    [SerializeField] public Upgrades upg;


    //first is Swoosh
    //second cash_sound
    public AudioClip[] sounds;

    public GameObject[] muffinUpgradeParticles;
    public GameObject[] muffinEndParticles;


    private bool isFristUpgradeInstance = false;
    private bool isSecondUpgradeInstance = false;
    int position_counter = 1;
    int mesh_num = 0;
    public int random_number;
    public int random_number2;
    public int random_number3;

    private void Awake()
    {
     
         upg=GetComponent<Upgrades>();
        //Upgrade 
        _speed = Upgrades.track_speed;
        _waitingTime = Upgrades.waiting_time;
        //Track
        trackGameObject = GameObject.FindGameObjectWithTag("Track");
        track = trackGameObject.GetComponent<Track>();


        //First muffin
        random_number = UnityEngine.Random.Range(0,5);
        mesh_list = _muffin.returnMuffinChildren(random_number);
        muffin = _muffin.returnMuffin(random_number);


        //SecondMuffin
        if (track.numberOfUpgrade > 0)
        {
            random_number2 = UnityEngine.Random.Range(0, 5);
            mesh_list_copy = _muffin_copy.returnMuffinChildren(random_number2);
            muffin_copy = _muffin_copy.returnMuffin(random_number2);
            isFristUpgradeInstance = true;

        }

        //ThirdMuffin
        if (track.numberOfUpgrade > 1)
        {
            random_number3 = UnityEngine.Random.Range(0, 5);
            mesh_list_copy2 = _muffin_copy2.returnMuffinChildren(random_number3);
            muffin_copy2 = _muffin_copy2.returnMuffin(random_number3);
            isSecondUpgradeInstance = true;

        }


    }

    private void Start()
    {
        
        _transform_target.x = x_positons[position_counter];
      

        if(!isFristUpgradeInstance )
        {
            muffin.SetActive(true);
            mesh_list[mesh_num].SetActive(true);
        }

        if (track.numberOfUpgrade==1 && isFristUpgradeInstance)
         {
            muffin.SetActive(true);
            muffin_copy.SetActive(true);

            mesh_list[mesh_num].SetActive(true);
            mesh_list_copy[mesh_num].SetActive(true);

            mesh_list_copy[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1f);
            mesh_list[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);

        }
        
        if(track.numberOfUpgrade== 2 && isSecondUpgradeInstance)
        {
            muffin.SetActive(true);
            muffin_copy.SetActive(true);
            muffin_copy2.SetActive(true);

            mesh_list[mesh_num].SetActive(true);
            mesh_list_copy[mesh_num].SetActive(true);
            mesh_list_copy2[mesh_num].SetActive(true);

            mesh_list[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
            mesh_list_copy[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1f);
            mesh_list_copy2[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);


        }
        

        position_counter++;
        mesh_num++;
    }

    private void Update()
    {


        //Update speed 
        if (UIManager.Instance.isTrackSpeedUpdated)
        {
            upg = GameObject.FindGameObjectWithTag("Upgrade").GetComponent<Upgrades>() ;
            upg.UpdateTrackSpeed(0.1f);

            UIManager.Instance.isTrackSpeedUpdated = false;
        }

        //Update Waiting time
        if (UIManager.Instance.isWaitinTimePriceUpdate)
        {
            upg = GameObject.FindGameObjectWithTag("Upgrade").GetComponent<Upgrades>();
            upg.UpdateWaitingTime(0.08f);

            UIManager.Instance.isWaitinTimePriceUpdate = false;
        }

        //Muffin movement
        if (!isWaiting)
        {
            if (transform.position.x <= _transform_target.x)
            { 
                //Vector based     
                    transform.position = new Vector3(this.transform.position.x + 0.1f*_speed, this.transform.position.y, this.transform.position.z);
                //Sound on movement
               
                
            }
            else
            {
                Debug.Log(_waitingTime);
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

            if (!isFristUpgradeInstance)
            {
                mesh_list[mesh_num].SetActive(true);
            }

            if (track.numberOfUpgrade == 1 && isFristUpgradeInstance)
            {
                mesh_list[mesh_num].transform.position= new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
                mesh_list[mesh_num].SetActive(true);

                mesh_list_copy[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1f);
                mesh_list_copy[mesh_num].SetActive(true);
           
            }

            if(track.numberOfUpgrade == 2 && isSecondUpgradeInstance)
            {
                mesh_list[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
                mesh_list[mesh_num].SetActive(true);

                mesh_list_copy[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1f);
                mesh_list_copy[mesh_num].SetActive(true);

                mesh_list_copy2[mesh_num].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                mesh_list_copy2[mesh_num].SetActive(true);
            }
            

            mesh_num++;
         }


        position_counter++;
        yield return new WaitForSeconds(_waitingTime);
         AudioSource.PlayClipAtPoint(sounds[0],new Vector3(_transform_target.x, _transform_target.y, _transform_target.z));
        //print("Wait complete");
        isWaiting = false;
    }

    IEnumerator End()
    {
        


        if (position_counter >= 5)
        {
            //Animation

            //Add music
            AudioSource.PlayClipAtPoint(sounds[1], new Vector3(_transform_target.x, this.transform.position.y, this.transform.position.y));




            //Add to hud score/money
            //Money once
            UIManager.Instance.IncreaseScore();

            if (track.numberOfUpgrade>0 && isFristUpgradeInstance)
            {
                //Money twice with incramented money
                UIManager.Instance.IncreaseScore();
            }

            if(track.numberOfUpgrade>1 && isSecondUpgradeInstance)
            {
                UIManager.Instance.IncreaseScore();
            }
            
            
            //Destory
            Destroy(gameObject);

        }
        yield return null;
    }

    //IF UPGRADE NUMBER ==1 
    //Copy muffin to prefab
    //Get all that muffin meshes.
    //Every Position mesh of another one activate.
    //Destroy(gameObject) 
    //if(upgrade) destory coppy too
    //UI update Money per cookie 20


}
