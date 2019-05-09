using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leve1SceneMgr : MonoBehaviour {
	public GameObject PlayerCam;
	public GameObject IntroCam1;
	public GameObject IntroCam2;
	public GameObject IntroCam3;
	public GameObject OutroCam1;
	public GameObject OutroCam2;
	public GameObject PushBox1;
	public GameObject PushBox2;
	public GameObject Chair;
	public GameObject TomeCruise;
	public GameObject GuideSphere;
	public GameObject TerribleNightclubMusic;
	bool check_for_end = false;
	public int timer = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (IntroSequence () );
	}
	void Update () {
		float BoxesDist = Vector3.Distance(PushBox1.transform.position, PushBox2.transform.position);
		float ChairDist = Vector3.Distance(PushBox2.transform.position, Chair.transform.position);
		if(BoxesDist <= 4 && ChairDist <= 4)
		{
			timer++;
			if(timer > 200 && !check_for_end)
			{
				check_for_end = true;
				StartCoroutine (OutroSequence () );
			}
		}
	}
	// Update is called once per frame
	IEnumerator IntroSequence () 
	{
		TerribleNightclubMusic.SetActive(false);
		IntroCam3.SetActive(false);
		IntroCam2.SetActive(false);
		GuideSphere.SetActive(false);
		TomeCruise.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam1.SetActive(false);
		OutroCam2.SetActive(false);
		IntroCam1.SetActive(true);
		yield return new WaitForSeconds(21);
		IntroCam1.SetActive(false);
		IntroCam2.SetActive(true);
		yield return new WaitForSeconds(22);
		IntroCam2.SetActive(false);
		IntroCam3.SetActive(true);
		PlayerCam.SetActive(true);
		yield return new WaitForSeconds(26);
		IntroCam3.SetActive(false);
		PlayerCam.SetActive(true);
		TerribleNightclubMusic.SetActive(true);
	}
	IEnumerator OutroSequence () 
	{
		TerribleNightclubMusic.SetActive(false);
		GuideSphere.SetActive(false);
		PlayerCam.SetActive(false);
		OutroCam1.SetActive(true);
		TomeCruise.SetActive(true);
		yield return new WaitForSeconds(15);
		OutroCam1.SetActive(false);
		OutroCam2.SetActive(true);
		yield return new WaitForSeconds(40);
		OutroCam2.SetActive(false);
		PlayerCam.SetActive(true);
		yield return new WaitForSeconds(10);
		GuideSphere.SetActive(true);
	}
}
