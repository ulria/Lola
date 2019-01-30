using UnityEngine;
using System.Collections;

public class GlobalNailCounter : MonoBehaviour {

	//global nailCounter = 0;
	public int nailCounter;

	// Use this for initialization
	void Start () {
		nailCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (nailCounter == 5) {
			GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		}
	}
}