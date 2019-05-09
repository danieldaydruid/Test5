using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_control : MonoBehaviour {
	public int Health = 10;
	public GameObject PushBox;
	public GameObject PushBox1;
	public bool HoldingBox = false;
	public int count = 0;
	public bool cursor_check = false;
	public float speed = 6.0F;
	public float gravity = 20.0F;
	public Vector3 curPos;
	public Vector3 lastPos;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public GameObject RaycastObject;



	void Start() {
	// Store reference to attached component
		controller = GetComponent<CharacterController>();
		PushBox = GameObject.Find("PushBox");
		PushBox1 = GameObject.Find("PushBox1");
		RaycastObject = GameObject.Find("/Player/RaycastObject");
	}

	void Update() {
		if(SceneManager.GetActiveScene().name == "Level4")
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		PlayerIsMoving();
		PlayerIsInteractingWithBox();
		LevelTransition();
		InCombatLevel();
		if(Input.GetKey(KeyCode.Escape)) {
				cursor_check = false;
			}
			if(Input.GetKey(KeyCode.Space)) {
				cursor_check = true;
			}
			if (cursor_check) {
				//Cursor.lockState = CursorLockMode.Locked;
				//Cursor.visible = false;
			}
			else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			if(SceneManager.GetActiveScene().name == "Level2")
			{
				if(controller.transform.position.y >= 10 || controller.transform.position.y <= -0.5)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					transform.position = new Vector3(0f, 3f, -46.45f);
					//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
				}
			}

	// Character is on ground (built-in functionality of Character Controller)
	if (controller.isGrounded) {
			if(Input.GetKey(KeyCode.Escape)) {
				cursor_check = false;
			}
			if(Input.GetKey(KeyCode.Space)) {
				cursor_check = true;
			}
			if (cursor_check) {
				//Cursor.lockState = CursorLockMode.Locked;
				//Cursor.visible = false;
			}
			else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			float rotLeftRight = Input.GetAxis("Mouse X");
			transform.Rotate(0, rotLeftRight, 0);
			
	// Use input up and down for direction, multiplied by speed
	moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	moveDirection = Camera.main.transform.TransformDirection(moveDirection);
	moveDirection *= speed;

	}
	// Apply gravity manually.
	moveDirection.y -= gravity * Time.deltaTime;
	// Move Character Controller
		controller.Move(moveDirection * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {

        //Debug.Log(col.gameObject.name);
		//Destroy(col.gameObject);
        if(other.gameObject.name == "EnemyBullet(clone)")
        {
			//GameObject confetti = col.gameObject.transform.GetChild(0).gameObject;
            Destroy(other.gameObject);
			//confetti.SetActive(true);
        }
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
		}
		if (count == 1) {
			Destroy(GameObject.Find("ZombieCube"));
		}
		if (count == 2) {
			Destroy(GameObject.Find("ZombieCube_1"));
		}
		if (count == 3) {
			Destroy(GameObject.Find("ZombieCube_2"));
		}
	}
	/*void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "PushBox")
		{
			Destroy(col.gameObject);
		}
	}*/
	public bool PlayerIsMoving()
	{
		bool temp = false;
		curPos = controller.transform.position;
		if(curPos == lastPos) temp = false;
		else temp = true;
		lastPos = curPos;
		return temp;
	}
	public bool PlayerIsInteractingWithBox()
	{
		RaycastHit hit;

		Vector3 fwd = RaycastObject.transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(RaycastObject.transform.position, fwd, out hit, 1))
		{
			if(hit.transform.gameObject.name == "PushBox")
			{
				if(Input.GetMouseButton(0)) {
					HoldingBox = true;
					PushBox.transform.parent = transform;
					return true;
				}
				if(Input.GetMouseButtonUp(0)) {
					HoldingBox = false;
					PushBox.transform.parent = null;
					return false;
				}
			}
			if(hit.transform.gameObject.name == "PushBox1")
			{
				if(Input.GetMouseButton(0)) {
					HoldingBox = true;
					PushBox1.transform.parent = transform;
					return true;
				}
				if(Input.GetMouseButtonUp(0)) {
					HoldingBox = false;
					PushBox1.transform.parent = null;
					return false;
				}
			}
		}
		/*if(Vector3.Distance(PushBox.transform.position, transform.position) <= 2.0f )
		{
			if(Input.GetMouseButton(0)) {
				PushBox.transform.parent = transform;
				return true;
			}
			if(Input.GetMouseButtonUp(0)) {
				PushBox.transform.parent = null;
				return false;
			}
		}*/
		return false;
	}
	void LevelTransition()
	{
		RaycastHit hit;
		Vector3 fwd = RaycastObject.transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(RaycastObject.transform.position, fwd, out hit, 5))
		{
			if(hit.transform.gameObject.name == "Exit" || hit.transform.gameObject.name == "LevelOneDoor" )
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
			if(hit.transform.gameObject.name == "LevelTwoDoor" )
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
			}
		}
	}
	public bool InCombatLevel()
	{
		if(SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "final_boss" )
		{
			return true;
		}
		else return false;
	}
	public bool IsFiring()
	{
		 if( Input.GetMouseButton(0) )
		 {
			 return true;
		 }
		 else return false;
	}
}