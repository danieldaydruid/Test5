using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour {
	bool SizeCapped = false;
	public float x1, y1, z1;
    void Update () 
    {
		if(transform.localScale.x > 10f)
		{
			SizeCapped = true;
		}
		if(transform.localScale.x < 0.5f)
		{
			SizeCapped = false;
		}
		if(SizeCapped) transform.localScale -= new Vector3(x1, y1, z1) * Time.deltaTime;
		if(!SizeCapped) transform.localScale += new Vector3(x1, y1, z1) * Time.deltaTime;
    }
}
//https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/creating-collectable-objects?playlist=17141
