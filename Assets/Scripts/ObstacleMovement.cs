﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleMovement : MonoBehaviour {
	public float speed;
	private float waitTime;
	public float startWaitTime;

	public Transform[] moveSpots;
	private int randomSpot;

	void Start() {
		randomSpot = Random.Range(0, moveSpots.Length);
	}

	void Update() {
		if (SceneManager.GetActiveScene().name != "final_boss") {
			transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
				if(waitTime <= 0) {
					randomSpot = Random.Range(0, moveSpots.Length);
					waitTime = startWaitTime;
				}
				else {
					waitTime -= Time.deltaTime;
				}
			}
		}
	}
}