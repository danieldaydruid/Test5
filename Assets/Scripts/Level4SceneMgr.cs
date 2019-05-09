using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4SceneMgr : MonoBehaviour {
	public bool Click1 = false, Click2 = false, Click3 = false;
	public GameObject PlayerCam;
	public GameObject IntroCam1;
	public GameObject IntroDialogue;
	public GameObject OutroDialogue;
	public GameObject SceneMusic;
	public GameObject IntroCam2;
	public GameObject OutroCam;
	public GameObject InteractiveCanvas;
	public Text Question;
	public int GuessesLeft = 3;
	public Text TriesRemaining;
	public Button Answer1;
	public Button Answer2;
	public Button Answer3;
	int KeepTrackOfQuestionNum = 0;
	public int timer = 0;
	public AudioClip MusicClip;
	public AudioSource MusicSource;
	// Use this for initialization
	void Start () {
		StartCoroutine (IntroSequence () );
	}
	
	// Update is called once per frame
	void Update () {
		TriesRemaining.text = "Tries Remaining: " + GuessesLeft.ToString() + "/3";
		StartCoroutine(HoldOn());
	}
	IEnumerator IntroSequence () 
	{

		OutroDialogue.SetActive(false);
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam.SetActive(false);
		IntroCam2.SetActive(false);
		InteractiveCanvas.SetActive(false);
		IntroDialogue.SetActive(true);
		IntroCam1.SetActive(true);
		yield return new WaitForSeconds(33);
		IntroCam1.SetActive(false);
		IntroCam2.SetActive(true);
		yield return new WaitForSeconds(32);
		IntroDialogue.SetActive(false);
		IntroCam2.SetActive(false);
		SceneMusic.SetActive(true);
		PlayerCam.SetActive(true);
		InteractiveCanvas.SetActive(true);
	}
	IEnumerator OutroSequence () 
	{
		InteractiveCanvas.SetActive(false);
		SceneMusic.SetActive(false);
		PlayerCam.SetActive(false);
		OutroDialogue.SetActive(true);
		OutroCam.SetActive(true);
		yield return new WaitForSeconds(54);
		SceneManager.LoadScene("final_boss");
	}
	void CheckAnswers1()
	{
		if(KeepTrackOfQuestionNum == 0 && !Click1)
		{
			Text txt1 = Answer1.transform.Find("Text").GetComponent<Text>();
			Text txt2 = Answer2.transform.Find("Text").GetComponent<Text>();
			Text txt3 = Answer3.transform.Find("Text").GetComponent<Text>();
			Question.text = "Who directed 'There Will be Blood'?";
			txt1.text = "Roger Ayer";
			txt2.text = "Sam Raimi";
			txt3.text = "Paul Thomas Anderson";
			KeepTrackOfQuestionNum++;
		}
		else if(KeepTrackOfQuestionNum != 0 && !Click1) {
			MusicSource.Play();
			if (GuessesLeft == 3){
				GuessesLeft = 2;
			}
			else if (GuessesLeft == 2) {
				GuessesLeft = 1;
			}
			else if (GuessesLeft == 1) SceneManager.LoadScene("Level4");
		}
		Click1 = true;
		Click2 = false;
		Click3 = false;
	}
	void CheckAnswers2()
	{
		if(KeepTrackOfQuestionNum == 2 && !Click2)
		{
			StartCoroutine (OutroSequence () );
		}
		else if(KeepTrackOfQuestionNum != 2 && !Click2) {
			MusicSource.Play();
			if (GuessesLeft == 3){
				GuessesLeft = 2;
			}
			else if (GuessesLeft == 2) {
				GuessesLeft = 1;
			}
			else if (GuessesLeft == 1) SceneManager.LoadScene("Level4");
		}
		Click2 = true;
		Click3 = false;
		Click1 = false;
	}
	void CheckAnswers3()
	{
		if(KeepTrackOfQuestionNum == 1 && !Click3)
		{
			Text txt1 = Answer1.transform.Find("Text").GetComponent<Text>();
			Text txt2 = Answer2.transform.Find("Text").GetComponent<Text>();
			Text txt3 = Answer3.transform.Find("Text").GetComponent<Text>();
			Question.text = "Whose Oscar do you think we have right here?";
			txt1.text = "Toby Maguire's";
			txt2.text = "... Leonardo's";
			txt3.text = "Steve-O's";
			KeepTrackOfQuestionNum++;
		}
		else if(KeepTrackOfQuestionNum != 1 && !Click3) {
			MusicSource.Play();
			if (GuessesLeft == 3){
				GuessesLeft = 2;
			}
			else if (GuessesLeft == 2) {
				GuessesLeft = 1;
			}
			else if (GuessesLeft == 1) SceneManager.LoadScene("Level4");
		}
		Click3 = true;
		Click2 = false;
		Click1 = false;
	}
	 IEnumerator HoldOn(){
		yield return new WaitForSeconds(5);
		Answer1.onClick.AddListener(CheckAnswers1);
		yield return new WaitForSeconds(5);
		Answer2.onClick.AddListener(CheckAnswers2);
		yield return new WaitForSeconds(5);
		Answer3.onClick.AddListener(CheckAnswers3);
	}
}