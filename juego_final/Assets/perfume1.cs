using UnityEngine;
using System.Collections;

public class perfume1 : MonoBehaviour {

	private Transform thisTransform;
	private float elapsedTime = 2;
	public BoxCollider thiscollider;

	void Awake(){
//		thiscollider = thisTransform.Rotate (Vector3.Angle);
	}
			

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown(){

	//	Rotation();
	}


	void Rotation( float elapsedTime)
	{
		thisTransform.Rotate(Vector3.forward * elapsedTime);
	}
}
