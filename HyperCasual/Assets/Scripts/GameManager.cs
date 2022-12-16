using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//small game that's not procedural(not heavy in code) not in need

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    //Can upgrade till certain number 
    //Can update until cettain number UI 
    
    private void Awake()
    {
        Instance = this;
    }
    


}
