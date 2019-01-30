using UnityEngine;
using System.Collections;

public class perfume : MonoBehaviour {

	private Transform thisTransform;
	private float elapsedTime = 2;
	public BoxCollider thiscollider;

	private int rotationAngle = 30;

	private bool success = false;

	void Awake(){
		//thiscollider = thisTransform.Rotate (Vector3.Angle);
	}
			

	// Use this for initialization
	void Start () {
		thisTransform = this.transform;

		int angleDepart = Random.Range (0, 11);
		angleDepart *= rotationAngle;
		thisTransform.Rotate(Vector3.forward * angleDepart);
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion correctRotation1 = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
		Quaternion correctRotation2 = new Quaternion (0.0f, 0.0f, 0.0f, -1.0f);
		if (thisTransform.rotation == correctRotation1 || thisTransform.rotation == correctRotation2){
			success = true;
		}
		if (success)
		{
			GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		}
	}

	void OnMouseDown()
	{
		Rotate ();
	}

	void Rotate()
	{
		thisTransform.Rotate(Vector3.forward * rotationAngle);
	}
}
