using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * 900 * Time.deltaTime);
	}
	void OnCollisionEnter (Collision col)
    {
        //Debug.Log(col.gameObject.name);
		//Destroy(col.gameObject);
        if(col.gameObject.name == "UprightZombie" || col.gameObject.name == "UprightZombieShooter" || col.gameObject.name == "EnemyBullet")
        {
			//GameObject confetti = col.gameObject.transform.GetChild(0).gameObject;
            Destroy(col.gameObject);
			//confetti.SetActive(true);
			Destroy(gameObject);
        }
		else if(col.gameObject.name == "Boss") {
			GameObject.Find("Boss").GetComponent<BossMove>().Health--;
		}
		if(GameObject.Find("Boss").GetComponent<BossMove>().Health <= 0) {
			Destroy(GameObject.Find("Boss"));
		}
    }
}
