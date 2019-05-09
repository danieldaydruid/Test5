using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneMgr : MonoBehaviour {
	public GameObject PlayerCam;
	public GameObject IntroCam1;
	public GameObject IntroCam2;
	public GameObject OutroCam;
	public GameObject FireController;
	public GameObject TitleSequence;
	public GameObject GuideSphere;
	public int timer = 0;
	// Use this for initialization
	void Start () {
				StartCoroutine (IntroSequence () );
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator IntroSequence () 
	{
		GuideSphere.SetActive(false);
		FireController.SetActive(false);
		TitleSequence.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam.SetActive(false);
		IntroCam2.SetActive(false);
		IntroCam1.SetActive(true);
		yield return new WaitForSeconds(130);
		FireController.SetActive(true);
		yield return new WaitForSeconds(100);
		IntroCam1.SetActive(false);
		IntroCam2.SetActive(true);
		yield return new WaitForSeconds(8);
		TitleSequence.SetActive(true);
		yield return new WaitForSeconds(9);
		TitleSequence.SetActive(false);
		IntroCam2.SetActive(false);
		PlayerCam.SetActive(true);
		yield return new WaitForSeconds(10);
		GuideSphere.SetActive(true);
	}
	IEnumerator OutroSequence () 
	{
		PlayerCam.SetActive(false);
		OutroCam.SetActive(true);
		yield return new WaitForSeconds(10);
	}
}