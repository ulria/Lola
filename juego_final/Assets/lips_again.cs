using UnityEngine;
using System.Collections;

public class lips_again : MonoBehaviour {

	public Rigidbody thisrigidbody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("button donw");
			ChangeColor();
		}

		if (Input.GetMouseButtonUp (0))
			Debug.Log ("button up");
	}

	void ChangeColor (){
		GetComponent<SpriteRenderer>().color = Color.red;
	}
}
