using UnityEngine;
using System.Collections;

public class scriptAnimationEndingSad : MonoBehaviour {

	private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= 9.50f) {
			Debug.Log ("Loading Title");
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Title");
		}
	}
}
