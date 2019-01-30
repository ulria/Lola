using UnityEngine;
using System.Collections;

public class scriptAnimationHouse : MonoBehaviour {

	private float elapsedTime = 0.0f;

	private bool carDestroyed = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (!carDestroyed) {
			if (elapsedTime >= 1.00f) {
				Debug.Log ("Destroying car");
				GameObject.FindGameObjectWithTag ("car").SetActive (false);
				carDestroyed = true;
			}
		}
		if (elapsedTime >= 3.00f) {
			Debug.Log ("Loading Hand");
			UnityEngine.SceneManagement.SceneManager.LoadScene ("hand");
		}
	}
}
