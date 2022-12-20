
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffinCount : MonoBehaviour
{

    private GameObject trackGameObject;
    private Track track;

    private GameObject firstMuffin;

    void Start()
    {
        firstMuffin = GameObject.FindGameObjectWithTag("Muffin");
        trackGameObject = GameObject.FindGameObjectWithTag("Track");
        track = trackGameObject.GetComponent<Track>();

    }

    // Update is called once per frame
    void Update()
    {
        if (track.numberOfUpgrade == 1)
        {
            SetTwoMuffins();
        }

        if (track.numberOfUpgrade == 2)
        {
            SetThreeMuffins();
        }

    }


    void SetTwoMuffins()
    {
        if (!track.isUpgraded)
        {
            Debug.Log("Added double muffins");
            firstMuffin.transform.position = new Vector3(firstMuffin.transform.position.x, firstMuffin.transform.position.y, 0.5f);
            GameObject secondMuffin = Instantiate(firstMuffin, new Vector3(firstMuffin.transform.position.x, this.firstMuffin.transform.position.y, -0.5f), Quaternion.identity);
            secondMuffin.transform.parent = this.transform.parent;

            track.isUpgraded = true;

        }
    }
    void SetThreeMuffins()
    {


    }
}
