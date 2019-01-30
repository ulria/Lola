using UnityEngine;
using System.Collections;

public class EyebrowControl : MonoBehaviour {

	public Rigidbody thisRigidBody;
	public BoxCollider[] thisCollider;


	AudioClip mario;



	// Use this for initialization
	void Start () {
		thisRigidBody = GetComponent<Rigidbody> ();
		thisCollider = GetComponents<BoxCollider> ();

	

	


		}
	
	void OnMouseDown()
	{
		DropIt();

		/*AudioSource audio = GetComponent<AudioSource>();
		audio.clip = mario;
		audio.Play();*/
		Debug.Log( "Enabled: " + GetComponent<AudioSource> ().enabled);
		if(!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource> ().PlayOneShot( mario );
		}
	}


	private void DropIt()
	{
		for (int i = 0; i < thisCollider.Length; i++)
		{
			thisCollider[i].enabled = false;
		}
		Debug.Log("DropIt");
		thisRigidBody.useGravity = true;
		thisRigidBody.isKinematic = false;
		GameObject.FindGameObjectWithTag ("CejasCounter").GetComponent<EyebrowControl1>().cejasCounter++;
	}
}
