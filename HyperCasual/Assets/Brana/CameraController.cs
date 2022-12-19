using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Camera main;
    [SerializeField] GameObject cameraTransform, cameraTransform1, cameraTransform2, cameraTransform3, cameraTransform4, cameraTransform5;
	public Vector3 testMove;
	public Transform tempObject;


    void Start()
    {
       
    }

    public void MoveToPosition()
    {
        StartCoroutine(MoveCamera(cameraTransform.transform.position, cameraTransform.transform.rotation, 1f));
Debug.Log("Moving To : " + cameraTransform.name);
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

