using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    public static int score = 0;
    //Camra anim
    public Animator _cameraAnimator;
    private bool camera_switch = false;
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
    AudioSource _buttonPressSource;

    //TrackSpeedUpgrade
    int trackSpeedUpgrade = 20;
    public TMP_Text _trackSpeedText;
    public bool isTrackSpeedUpdated = false;


    private void Awake()
    {
        Instance= this;
        _buttonPressSource= GetComponent<AudioSource>();
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
            _buttonPressSource.Play();
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
        pressed = true;
        _buttonPressSource.Play();
        ButtonAnimators[1].SetBool("pressed", true);
        pressed = false;
    }
    public void UnitOneUpdate()
    {
        pressed = true;
        ButtonAnimators[2].SetBool("pressed", true);
        pressed = false;

        ButtonAnimators[2].SetBool("pressed", false);
    }
    public void UnitTwoUpdate()
    {
        pressed = true;
        ButtonAnimators[3].SetBool("pressed", true);
        pressed = false;
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

    public void SwitchCamera()
    {
        PanelSwitch();

        Time.timeScale = 1;
        if (!camera_switch){
            camera_switch = true;
            _cameraAnimator.SetBool("switch", camera_switch);
        }else
            camera_switch= false;
        _cameraAnimator.SetBool("switch", camera_switch);
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
