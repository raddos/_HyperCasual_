using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Muffin : MonoBehaviour
{

    [SerializeField] GameObject[] mufin_list;

    private GameObject type;


    public GameObject returnMuffin(int randomNumber)
    {
        return mufin_list[randomNumber];
    }

    public GameObject[] returnMuffinChildren(int randomNumber)
    {
        GameObject[] children = new GameObject[5];

        type = mufin_list[randomNumber];

        for(int i = 0; i < 5;i++) 
        {
            children[i] = type.transform.GetChild(i).GameObject();
        }

        return children;
    }
}
