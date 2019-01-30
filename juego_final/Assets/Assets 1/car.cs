using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	private float moveSpeed =2.5f;
	private Transform thisTransform;
	private float newX, newY, newZ;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		newX = thisTransform.position.x + (moveSpeed * Time.deltaTime);
		newY = thisTransform.position.y;
		newZ = thisTransform.position.z;
		newPos = new Vector3(newX, newY, newZ);
		thisTransform.position = newPos;
	
	}
}
