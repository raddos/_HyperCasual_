using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AnimateCameraAngle : MonoBehaviour
{
    public Camera main;
    [SerializeField] GameObject cameraTransform1, cameraTransform2, cameraTransform3, cameraTransform4, cameraTransform5;
    [SerializeField] GameObject cameraDebugTransform;

    private Track track;

    private void Start()
    {
        track = GameObject.FindGameObjectWithTag("Track").GetComponent<Track>();
    }

    public void MovePosition()
    {
        switch (track.numberAddedTracks)
        {
            case 0:
                MoveToPosition1();
               
                break;
            case 1:
                MoveToPosition2();
                Debug.Log("Started Moving");
                break;
            case 2:
                MoveToPosition3();
                break;
            case 3:
                  MoveToPosition4();
                break;
            case 4:
                MoveToPosition5();
                break;
        }
    }

    public void DebugMovePosition()
    {
        StartCoroutine(MoveCamera(cameraDebugTransform.transform.position, cameraDebugTransform.transform.rotation, 1f));
    }

    public void MoveToPosition1()
    {
        StartCoroutine(MoveCamera(cameraTransform1.transform.position, cameraTransform1.transform.rotation, 1f));
    }
    public void MoveToPosition2()
    {
        StartCoroutine(MoveCamera(cameraTransform2.transform.position, cameraTransform2.transform.rotation, 1f));
    }
    public void MoveToPosition3()
    {
        StartCoroutine(MoveCamera(cameraTransform3.transform.position, cameraTransform3.transform.rotation, 1f));
    }
    public void MoveToPosition4()
    {
        StartCoroutine(MoveCamera(cameraTransform4.transform.position, cameraTransform4.transform.rotation, 1f));
    }
    public void MoveToPosition5()
    {
        StartCoroutine(MoveCamera(cameraTransform5.transform.position, cameraTransform5.transform.rotation, 1f));
    }




    public IEnumerator MoveCamera(Vector3 targetPosition, Quaternion targetRotation, float duration)
    {
        float time = 0;
        Vector3 startPosition = main.transform.position;
        Quaternion startRotation = main.transform.rotation;

        while (time < duration)
        {
            main.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            main.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }
}