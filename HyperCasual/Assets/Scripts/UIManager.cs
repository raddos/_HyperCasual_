using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    //Panels 
    public GameObject _debugPanel;
    public GameObject _gamePanel;
 
    //--- Game Panel
    //Money-Score
    public TMP_Text _score;
    //ScoreCheck
    int number = 10;

    //--- Debug Panel

    private void Start()
    {

        Score();
    }

    public void OnClick()
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
        //Freeze Scene
        Time.timeScale = 0;
    }


    public void Resume()
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
        //Freeze Scene
        Time.timeScale = 1;
    }

    public void Score()
    {
        _score.text += number.ToString();
    }

 
}
