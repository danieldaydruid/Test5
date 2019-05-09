using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * 900 * Time.deltaTime);
	}
	void OnCollisionEnter (Collision col) //FIX THIS
    {
        //Debug.Log(col.gameObject.name);
		//Destroy(col.gameObject);
        if(col.gameObject.name == "Player")
        {
			//GameObject confetti = col.gameObject.transform.GetChild(0).gameObject;
            //Destroy(col.gameObject);
			//confetti.SetActive(true);
            GameObject.Find("Player").GetComponent<Player_control>().Health--;
			Destroy(gameObject);
        }
    }
}
