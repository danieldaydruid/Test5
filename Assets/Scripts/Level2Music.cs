﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Level2Music : MonoBehaviour {
	public GameObject _Player_control;
	public float TotalTime;
	public AudioClip MusicClip;
	public AudioSource MusicSource;
	// Use this for initialization
	void Start () {
		MusicSource.clip = MusicClip;
		MusicSource.Play();
		TotalTime = 60f;
	}
	
	// Update is called once per frame
	void Update () {
		Text myTXT = GameObject.Find("Canvas/Text").GetComponent<Text>();
		TotalTime -= Time.deltaTime;
		myTXT.text = "Time Remaining: " + Math.Round(TotalTime, 2).ToString() + " seconds";
		if(TotalTime <= 0f) SceneManager.LoadScene("Level2");
	}
}