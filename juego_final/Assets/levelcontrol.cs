﻿using UnityEngine;
using System.Collections;

public class levelcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp(KeyCode.Alpha1)){
			
			Application.LoadLevel("face");
		}
	
	}
}
