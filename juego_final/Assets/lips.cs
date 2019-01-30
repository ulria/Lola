using UnityEngine;
using System.Collections;

public class lips : MonoBehaviour {

	private Transform thisTransform;
	private Vector3 moveDirection;
	private float moveSpeed;
	private float updateTime = 1.0f;
	private float elapsedTime = 0;

	public int speedAdjustement = 80;

	// Use this for initialization
	void Start () {
	
		thisTransform = this.transform;

		int xSpeed = Random.Range (3, 8);
		int ySpeed = Random.Range (3, 8);
		int directionX = Random.Range (0, 1);
		if (directionX == 0) {
			directionX = -1;
		} else {
			directionX = 1;
		}
		int directionY = Random.Range (0, 1);
		if (directionY == 0) {
			directionY = -1;
		}
		else {
			directionY = 1;
		}
		thisTransform.GetComponent<Rigidbody> ().AddForce (new Vector3 (directionX * xSpeed, directionY * ySpeed, 0)*speedAdjustement);
	}


	// Update is called once per frame
	void Update () {
		elapsedTime = elapsedTime + Time.deltaTime;
		if (elapsedTime >= updateTime) {
			//ApplyNewMoving ();
		}

		thisTransform.position = thisTransform.position + (moveDirection * 2 * moveSpeed * Time.deltaTime);
			
		/*if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("button donw");
			if(isInsideLips())
			{
				ChangeColor();	
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("button up");
			RechangeColor ();
		}*/
	}

	void OnMouseDown()
	{
		ChangeColor();
	}

	private void ApplyNewMoving()
	{
		moveDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f),0);
		moveDirection.Normalize ();

		moveSpeed = Random.Range (-5.0f, 5.0f);

		//if(/*position hors du frame, change la direction*/)
		//{}

		elapsedTime = 0;
	}

	void ChangeColor (){
		//if(GetComponent<SpriteRenderer>().color == Color.magenta)
		//{
		GetComponent<SpriteRenderer>().color = Color.red;
		GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
		GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		//}
	}

	void RechangeColor()
	{
		GetComponent<SpriteRenderer>().color = Color.blue;
	}

	void OnCollisionEnter(Collision other)
	{
		int xSpeed = Random.Range (3, 8);
		int ySpeed = Random.Range (3, 8);
		int directionX = Random.Range (0, 1);
		if (directionX == 0) {
			directionX = -1;
		} else {
			directionX = 1;
		}

		int directionY = Random.Range (0, 1);
		if (directionY == 0) {
			directionY = -1;
		}
		else {
			directionY = 1;
		}

		if(other.gameObject.CompareTag("WallRight"))
		{
			thisTransform.GetComponent<Rigidbody> ().AddForce (new Vector3 (-1 * xSpeed - 5, directionY * ySpeed, 0)*speedAdjustement);
		}else if(other.gameObject.CompareTag("WallLeft"))
		{
			thisTransform.GetComponent<Rigidbody> ().AddForce (new Vector3 (directionX * xSpeed + 5, ySpeed, 0)*speedAdjustement);
		}else if(other.gameObject.CompareTag("WallUp"))
		{
			thisTransform.GetComponent<Rigidbody> ().AddForce (new Vector3 (directionX * xSpeed, -1 * ySpeed - 5, 0)*speedAdjustement);
		}else if(other.gameObject.CompareTag("WallDown"))
		{
			thisTransform.GetComponent<Rigidbody> ().AddForce (new Vector3 (directionY * xSpeed, ySpeed + 5, 0)*speedAdjustement);
		}
	}
}