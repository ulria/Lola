using UnityEngine;
using System.Collections;

public class Eyeliner1 : MonoBehaviour {

	public int eyelinerCounter = 0;
	private int eyeliner1Counter = 0;
	public int numberEyelinerPrefabs = 10;

	public GameObject[] eyeliners1 = new GameObject[5];

	/*public GameObject eyelinerPrefab1_1; 
	public GameObject eyelinerPrefab1_2; 
	public GameObject eyelinerPrefab1_3; 
	public GameObject eyelinerPrefab1_4; 
	public GameObject eyelinerPrefab1_5;*/

	private Vector3[] eyeliner1Pos = new Vector3[5];

	// Use this for initialization
	void Start () {
		//eyeliners1[0] = eyelinerPrefab1_1;
		eyeliner1Pos [0] = new Vector3 (-5.5f, 0.25f, 0f);

		//eyeliners1 [1] = eyelinerPrefab1_2;
		eyeliner1Pos [1] = new Vector3 (-6.2f, 1.16f, 0f);
			
		//eyeliners1 [2] = eyelinerPrefab1_3;
		eyeliner1Pos [2] = new Vector3 (-7.9f, 1f, 0f);
				
		//eyeliners1 [3] = eyelinerPrefab1_4;
		eyeliner1Pos [3] = new Vector3 (-8.55f, 0f, 0f);
					
		//eyeliners1 [4] = eyelinerPrefab1_5;
		eyeliner1Pos [4] = new Vector3 (-8.7f, -0.6f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (eyelinerCounter == numberEyelinerPrefabs) {
			GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		}
	}

	void OnMouseDown()
	{
		if(eyeliner1Counter < (numberEyelinerPrefabs/2))
		{
			GameObject go = (GameObject) Instantiate (eyeliners1[eyeliner1Counter], eyeliner1Pos[eyeliner1Counter], new Quaternion());
			go.SetActive(true);
			eyeliner1Counter++;
			eyelinerCounter++;
		}
	}
}
