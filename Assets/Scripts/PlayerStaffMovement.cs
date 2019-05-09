﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaffMovement : MonoBehaviour {
	public GameObject Bullet_Emitter;
 
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
 
    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

	public GameObject _Player_control;
	public float speed;
	private float waitTime;
	public float startWaitTime;

	public Transform[] moveSpots;
	private int randomSpot;
	bool BoxCheck = false;
	float BulletTime = 0f;
	bool ShootingMagic = false;
	public AudioSource audio;
	void Start() {
		randomSpot = Random.Range(0, moveSpots.Length);
	}

	void Update() {
		BulletTime += Time.deltaTime;
		if(_Player_control.GetComponent<Player_control>().PlayerIsInteractingWithBox())
		{
			//transform.position = _Player_control.GetComponent<Player_control>().transform.position + new Vector3(0.0f, 1.4f, 0.8f);
			transform.position = GameObject.Find("/Player/WeaponSheath").transform.position;
			transform.rotation = GameObject.Find("/Player/WeaponSheath").transform.rotation;
			BoxCheck = true;
		}
		else
		{
			if (BoxCheck == true){
				transform.position = GameObject.Find("/Player/WeaponOut").transform.position;
				transform.rotation = GameObject.Find("/Player/WeaponOut").transform.rotation;
				BoxCheck = false;
			}
			if (_Player_control.GetComponent<Player_control>().PlayerIsMoving())
			{
				//Can un-comment this if you want the staff to spin around in a circle,
				//or you can modify the 3 float values (x, y, z) to make it do rotate other ways.
				//transform.Rotate(10f, 0f, 10f, Space.Self);
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
		if(_Player_control.GetComponent<Player_control>().InCombatLevel())
		{
			if(_Player_control.GetComponent<Player_control>().IsFiring() && BulletTime > 2f)
			{
			BulletTime = 0f;
			//transform.position = _Player_control.GetComponent<Player_control>().transform.position + new Vector3(0.0f, 1.4f, 0.8f);
			//transform.position = GameObject.Find("/Player/WeaponAttack").transform.position;
			//transform.rotation = GameObject.Find("/Player/WeaponAttack").transform.rotation;
			ShootingMagic = true;
			//Point forward
			//transform.Rotate(10f, 10f, 10f, Space.Self);
			GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
 
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
 
            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
 
            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
 
            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 3.0f);
			}
			else
			{
				if(ShootingMagic == true)
				{
					AudioClip clip = (AudioClip)Resources.Load("audio/BulletNoise");
    				audio.PlayOneShot(clip, 0.7f);
					transform.position = GameObject.Find("/Player/WeaponOut").transform.position;
					transform.rotation = GameObject.Find("/Player/WeaponOut").transform.rotation;
					ShootingMagic = false;
				}
			}
		}
	}
}