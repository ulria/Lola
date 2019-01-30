using UnityEngine;
using System.Collections;

public class scriptAnimationCar : MonoBehaviour {

	private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= 3.00f) {
			Debug.Log ("Changing scene");
			UnityEngine.SceneManagement.SceneManager.LoadScene("house-bell");
		}
	}
}
