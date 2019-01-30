using UnityEngine;
using System.Collections;

public class EyebrowControl1 : MonoBehaviour {


	//public Transform eyebrows;
	public GameObject eyebrows;

	public int cejasCounter;
	public int totalNum;

	void Awake()
	{
		//float x, y, z;
		//x = Random.Range (-0.05f, 2.6f);
		//y = Random.Range (-0.04f, 1.0f);
		//z = 0;
		//var go = Instantiate (eyebrows, new Vector3 (x, y, z), new Quaternion());
		//Instantiate(eyebrows, new Vector3(x, y, z), Quaternion.identity);

		Physics.IgnoreLayerCollision (LayerMask.NameToLayer ("cejas"), LayerMask.NameToLayer ("cejas"));

		cejasCounter = 0;
		totalNum = Random.Range (1, 10);
	}

	// Use this for initialization
	void Start () {

		float x, y, z;
		for(int i = 0; i < totalNum; i++)
		{
			x = Random.Range (-5.00f, -1.40f);
			y = Random.Range (2.00f, 3.80f);
			z = 0;
			var go = Instantiate (eyebrows, new Vector3 (x, y, z), new Quaternion());
			//Instantiate(this.transform, new Vector3(x, y, z), Quaternion.identity);
		}
	}
	
	void Update()
	{
		if (cejasCounter >= totalNum) {
			GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		}
	}
}
