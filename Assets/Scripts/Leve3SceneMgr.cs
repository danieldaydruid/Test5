using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leve3SceneMgr : MonoBehaviour {
	private int PlayerHealth;
	public GameObject PlayerCam;
	public GameObject PlayerBody;
	public GameObject SceneMusic;
	public GameObject IntroDialogue;
	public GameObject OutroDialogue;
	public GameObject IntroCam1;
	public GameObject OutroCam;
	public GameObject Oscar;
	public GameObject Enemies;
	public Text PlayerHealthString;

	public bool check_for_end = false;
	// Use this for initialization
	void Start () {
		PlayerHealth = PlayerCam.GetComponent<Player_control>().Health;
		StartCoroutine (IntroSequence () );
	}
	
	// Update is called once per frame
	void Update () {
		PlayerHealth = PlayerCam.GetComponent<Player_control>().Health;
		if(PlayerHealth <= 0) SceneManager.LoadScene("Level3");
		float dist = Vector3.Distance(Oscar.transform.position, PlayerBody.transform.position);
		if(dist <= 3)
		{
			if(!check_for_end)
			{
				check_for_end = true;
				StartCoroutine (OutroSequence () );
			}
		}
		PlayerHealthString.text = "Health: " + PlayerHealth.ToString() + "/5";
	}
	IEnumerator IntroSequence () 
	{
		OutroDialogue.SetActive(false);
		Enemies.SetActive(false);
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam.SetActive(false);
		IntroCam1.SetActive(true);
		IntroDialogue.SetActive(true);
		yield return new WaitForSeconds(97);
		IntroCam1.SetActive(false);
		IntroDialogue.SetActive(false);
		SceneMusic.SetActive(true);
		PlayerCam.SetActive(true);
		Enemies.SetActive(true);

	}
	IEnumerator OutroSequence () 
	{
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroDialogue.SetActive(true);
		OutroCam.SetActive(true);
		yield return new WaitForSeconds(40);
		SceneManager.LoadScene("Level4");
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
