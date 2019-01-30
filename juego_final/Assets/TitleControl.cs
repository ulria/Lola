using UnityEngine;
using System.Collections;

public class TitleControl : MonoBehaviour {

	//public timer script;

	// Use this for initialization
	void Start () {
		//script = GetComponent<timer>();
	}

	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp(KeyCode.Alpha1)){
			
			UnityEngine.SceneManagement.SceneManager.LoadScene("scenes");
			//UnityEngine.SceneManagement.SceneManager.LoadScene("hair");

			//script.enabled = true;
		}
	
	}
}
