using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIButtonAnimation : MonoBehaviour
{
	public bool wasClicked;
    public void AnimateButton()
{
	if(!wasClicked){

	transform.DOPunchScale(new Vector3(-0.2f, -0.2f, -0.2f), 0.3f, 1, 0.5f);
		StartCoroutine(DelayTimer());
	}
}
	public IEnumerator DelayTimer()
	{
		wasClicked=true;
		yield return new WaitForSeconds(0.3f);
		wasClicked=false;
		
}	


}
