using UnityEngine;
using System.Collections;

public class Eyeliner2 : MonoBehaviour {

	private int eyeliner2Counter = 0;
	public int numberEyelinerPrefabs = 10;

	public GameObject[] eyeliners2 = new GameObject[5];

	private Vector3[] eyeliner2Pos = new Vector3[5];

	public Eyeliner1 eyeliner1;

	// Use this for initialization
	void Start () {
		//eyeliners1[0] = eyelinerPrefab1_1;
		eyeliner2Pos [0] = new Vector3 (4.5f , 0.25f , 0f);

		//eyeliners1 [1] = eyelinerPrefab1_2;
		eyeliner2Pos [1] = new Vector3 (5.2f , 1.16f , 0f);

		//eyeliners1 [2] = eyelinerPrefab1_3;
		eyeliner2Pos [2] = new Vector3 (6.9f , 1f , 0f);

		//eyeliners1 [3] = eyelinerPrefab1_4;
		eyeliner2Pos [3] = new Vector3 (7.55f , 0f , 0f);

		//eyeliners1 [4] = eyelinerPrefab1_5;
		eyeliner2Pos [4] = new Vector3 (7.7f , -0.6f , 0f);

		eyeliner1 = GameObject.FindGameObjectWithTag ("BoxColliderEyeliner").GetComponent<Eyeliner1>();
	}

	// Update is called once per frame
	void Update () {
		/*if (eyeliner1.eyelinerCounter == numberEyelinerPrefabs) {
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<timer> ().ChangeLevel ();
		}*/
	}

	void OnMouseDown()
	{
		if(eyeliner2Counter < (numberEyelinerPrefabs/2))
		{
			GameObject go = (GameObject) Instantiate (eyeliners2[eyeliner2Counter], eyeliner2Pos[eyeliner2Counter], new Quaternion());
			go.SetActive(true);
			eyeliner2Counter++;
			eyeliner1.eyelinerCounter++;
		}
	}
}

