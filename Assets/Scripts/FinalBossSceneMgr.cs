using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalBossSceneMgr : MonoBehaviour {
	private int PlayerHealth;
	private int BossHealth;
	public GameObject EndingBarSounds;
	public GameObject EndingMusic;
	public GameObject PlayerCam;
	public GameObject Canvas1;
	public GameObject PlayerBody;
	public GameObject SceneMusic;
	public GameObject IntroDialogue;
	public GameObject OutroDialogue;
	public GameObject IntroCam1;
	public GameObject OutroCam;
	public GameObject Enemies;
	public Text PlayerHealthString;
	public Text BossHealthString;
	public GameObject TheEndCanvas;
	public int FinalBossHealth = 100;

	public bool check_for_end = false;
	// Use this for initialization
	void Start () {
		StartCoroutine (IntroSequence () );
	}
	
	// Update is called once per frame
	void Update () {
		PlayerHealth = PlayerCam.GetComponent<Player_control>().Health;
		BossHealth  = GameObject.Find("Boss").GetComponent<BossMove>().Health;
		if(PlayerHealth <= 0) SceneManager.LoadScene("final_boss");
		if(BossHealth <= 100)
		{
			if(!check_for_end)
			{
				check_for_end = true;
				StartCoroutine (OutroSequence () );
			}
		}
		PlayerHealthString.text = "Health: " + PlayerHealth.ToString() + "/5";
		BossHealthString.text = "Boss HP: " + BossHealth.ToString() + "/100";
	}
	IEnumerator IntroSequence () 
	{
		EndingBarSounds.SetActive(false);
		EndingMusic.SetActive(false);
		TheEndCanvas.SetActive(false);
		Canvas1.SetActive(false);
		OutroDialogue.SetActive(false);
		Enemies.SetActive(false);
		SceneMusic.SetActive(false);
		//PlayerCam.SetActive(false);
		OutroCam.SetActive(false);
		IntroCam1.SetActive(true);
		IntroDialogue.SetActive(true);
		yield return new WaitForSeconds(67);
		Canvas1.SetActive(true);
		IntroCam1.SetActive(false);
		IntroDialogue.SetActive(false);
		SceneMusic.SetActive(true);
		PlayerCam.SetActive(true);
	    Enemies.SetActive(true);

	}
	IEnumerator OutroSequence () 
	{
		Enemies.SetActive(false);
		Canvas1.SetActive(false);
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroDialogue.SetActive(true);
		OutroCam.SetActive(true);
		EndingMusic.SetActive(true);
		yield return new WaitForSeconds(54);
		EndingBarSounds.SetActive(true);
		yield return new WaitForSeconds(20);
		TheEndCanvas.SetActive(true);
		yield return new WaitForSeconds(45);
		SceneManager.LoadScene("main_menu");
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
