using UnityEngine;
using System.Collections;

public class scriptAnimationHand : MonoBehaviour {

	private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= 3.00f) {
			Debug.Log ("Loading FinalScene");
			Debug.Log ("Successful levels : " + GameObject.Find ("GlobalCounter").GetComponent<GlobalCounterScript> ().numberSuccessfulLevels);
			Debug.Log ("Goal : " + GameObject.Find ("GlobalCounter").GetComponent<GlobalCounterScript> ().successfulLevelsGoal);
			if (GameObject.Find ("GlobalCounter").GetComponent<GlobalCounterScript> ().numberSuccessfulLevels >= GameObject.Find ("GlobalCounter").GetComponent<GlobalCounterScript> ().successfulLevelsGoal) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("lola_ending-happy");
			} else {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("lola_ending_sad");
			}
		}
	}
}
