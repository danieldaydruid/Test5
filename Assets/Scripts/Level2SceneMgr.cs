using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2SceneMgr : MonoBehaviour {
	public GameObject PlayerCam;
	public GameObject PlayerBody;
	public GameObject SceneMusic;
	public GameObject IntroDialogue;
	public GameObject IntroCam1;
	public GameObject IntroCam2;
	public GameObject OutroCam;
	public GameObject Oscar;
	public bool check_for_end = false;
	// Use this for initialization
	void Start () {
		StartCoroutine (IntroSequence () );
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(Oscar.transform.position, PlayerBody.transform.position);
		if(dist <= 3)
		{
			if(!check_for_end)
			{
				check_for_end = true;
				StartCoroutine (OutroSequence () );
			}
		}
	}
	IEnumerator IntroSequence () 
	{
		IntroCam2.SetActive(false);
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam.SetActive(false);
		IntroCam1.SetActive(true);
		IntroDialogue.SetActive(true);
		yield return new WaitForSeconds(33);
		IntroCam1.SetActive(false);
		IntroCam2.SetActive(true);
		yield return new WaitForSeconds(46);
		IntroCam2.SetActive(false);
		IntroDialogue.SetActive(false);
		SceneMusic.SetActive(true);
		PlayerCam.SetActive(true);

	}
	IEnumerator OutroSequence () 
	{
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam.SetActive(true);
		yield return new WaitForSeconds(41);
		SceneManager.LoadScene("Level3");
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
