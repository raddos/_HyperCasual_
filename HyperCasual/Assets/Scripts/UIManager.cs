using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    public static int score = 10000000;
    //Camera anim
    public Animator _cameraAnimator;
    private bool camera_switch = false;
    public GameObject cameraNewPositions;
    public AnimateCameraAngle animCamAngle;
    //Panels 
    public GameObject _debugPanel;
    public GameObject _gamePanel;
 
    //--- Game Panel

    //Money-Score
    public TMP_Text _score;

    //ScoreCheck
    int money_per_cookie_base = 10;
    public Animator[] ButtonAnimators;
    private bool pressed = false;
    AudioSource _buttonPressAudioSource;


    //WaitingTime upgrade
    public TMP_Text _waitingTimeText;
    private int waitingTimePrice = 20;
    public bool isWaitinTimePriceUpdate = false;


    //Spawn Time upgrade
    public TMP_Text _spawnTimeUpgrade;
    private int SpawnTimeUpgradePrice = 40;
    public bool isSpawnTimeUpdate = false;

    //TrackSpeedUpgrade functionality
    int trackSpeedUpgrade = 20;
    public TMP_Text _trackSpeedText;
    public bool isTrackSpeedUpdated = false;
 
    //Unit Price Upgrade
    public TMP_Text _unitUpgradeText;
    private int unitUpgradePrice = 15;

    //AddTrack functinality
    public TMP_Text _addtrackText;
    public Button addTrackButton;
    public Track tracks;
    private int trackAddPrice = 1500;



    //Track upgrade
    //variables are in tracks scrip
    public Button upgradeTrackButton;
    public Animator upgradeTrackAnimator;
    public TMP_Text trackUpgradeText;
    private int trackUpgradePrice = 2000;
    public AudioSource upgradeTrackSound;


    //Debug
    bool swichedForDebug = false;

    private void Awake()
    {
        Instance= this;
        _buttonPressAudioSource = GetComponent<AudioSource>();   
        //animCamAngle = cameraNewPositions.GetComponent<AnimateCameraAngle>();
    }

    private void Start()
    {
        //Set all prices to textfields;
        _score.text = score.ToString();
        
    }

    public void IncreaseScore()
    {
        score += money_per_cookie_base;
        _score.text = score.ToString();
    }

    public void DecreasScore(int upgradeCost)
    {
        score -= upgradeCost;
        _score.text = score.ToString();
    }




    #region GamePanel

    public void TrackSpeedUpdate()
    {
            pressed = true;
            _buttonPressAudioSource.Play();
            ButtonAnimators[0].SetBool("pressed", true);
            pressed = false;
             ButtonAnimators[0].SetBool("pressed", false);
    
        if (score >= trackSpeedUpgrade)
        {
            DecreasScore(trackSpeedUpgrade);
            trackSpeedUpgrade += 15;
            _trackSpeedText.text = trackSpeedUpgrade.ToString();
            isTrackSpeedUpdated = true;
        }
    }

    public void SpawnTimeUpdate()
    {
        _buttonPressAudioSource.Play();
        pressed = true;  
        ButtonAnimators[1].SetBool("pressed", true);
        pressed = false;


        if (score >= SpawnTimeUpgradePrice)
        {
            DecreasScore(SpawnTimeUpgradePrice);
            SpawnTimeUpgradePrice += 15;
            _spawnTimeUpgrade.text = SpawnTimeUpgradePrice.ToString();
            isSpawnTimeUpdate = true;
        }
    }




    public void UnitUpdate()
    {
        _buttonPressAudioSource.Play();
        pressed = true;
        ButtonAnimators[2].SetBool("pressed", true);
        pressed = false;

        if(score > unitUpgradePrice)
        {
            DecreasScore(unitUpgradePrice);
            money_per_cookie_base += 1;
            
            unitUpgradePrice += 100;
            _unitUpgradeText.text=unitUpgradePrice.ToString();
           
        }

    }

    public void WaitingTimeUpdate()
    {
        _buttonPressAudioSource.Play();
        pressed = true;
        ButtonAnimators[3].SetBool("pressed", true);
        pressed = false;

        if (score > waitingTimePrice)
        {
            DecreasScore(waitingTimePrice);
            waitingTimePrice += 40;
            _waitingTimeText.text = waitingTimePrice.ToString();
            isWaitinTimePriceUpdate = true;
        }


    }



    public void AddTrack()
    {
        if (score >= trackAddPrice)
        {
          
            DecreasScore(trackAddPrice);
            trackAddPrice *= 2;
            _addtrackText.text= trackAddPrice.ToString();
            if (tracks.numberAddedTracks < 4)
            {
                Debug.Log("Start moving camera");
                animCamAngle.MovePosition();
                _buttonPressAudioSource.Play();
                tracks.numberAddedTracks++;
                tracks.AddTrack();
            }
            else
                addTrackButton.interactable = false;
        }


     }
    public void UpgradeTrack()
    {
        if (score >= trackUpgradePrice)
        {
          
            DecreasScore(trackSpeedUpgrade);
            trackUpgradePrice *= 6;
            trackUpgradeText.text = trackUpgradePrice.ToString();
            tracks.numberOfUpgrade++;
            _buttonPressAudioSource.Play();
            upgradeTrackSound.Play();
            if (tracks.numberOfUpgrade == 2)
            {
                upgradeTrackButton.interactable = false;
                upgradeTrackAnimator.enabled = false;
            }
        }
        
    }

    #endregion

    #region DebugMenuButtonOptions

    public void OnClick()
    {
        PanelSwitch();
        //Freeze Scene
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PanelSwitch();
        //Unfreeze
        Time.timeScale = 1f;
    }

    public void ToggleSound()
    {
        if(AudioListener.volume==0)
            AudioListener.volume = 1;
        else
            AudioListener.volume = 0;
    }

    public void SwitchCamera()
    {
        PanelSwitch();

        Time.timeScale = 1;
        if (swichedForDebug)
        {
            animCamAngle.DebugMovePosition();
            swichedForDebug = true;
        }
        else
            animCamAngle.MovePosition();
    }

    private void PanelSwitch()
    {
        if (_debugPanel != null)
        {
            bool isActive = _debugPanel.activeSelf;
            _debugPanel.SetActive(!isActive);
        }


        if (_gamePanel != null)
        {
            bool isActive = _gamePanel.activeSelf;
            _gamePanel.SetActive(!isActive);
        }
    }

#endregion
}
