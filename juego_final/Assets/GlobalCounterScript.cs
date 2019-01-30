using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GlobalCounterScript : MonoBehaviour {

	public int loadedSceneCounter = 0;
	public int lastLevel;
	public int numberSuccessfulLevels = 0;
	public int successfulLevelsGoal = 6;

	public bool[] scenesPlayedThisLoop = { false, false, false, false, false, false, true };

	AudioClip music;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
		SceneManager.sceneLoaded += this.OnLoadCallback;
		lastLevel = 0;

		AudioSource audio = GetComponent<AudioSource>();

		//audio.Play();
		//WaitForSeconds(audio.clip.length);
		audio.clip = music;
		audio.Play();
	}
		
	public void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
	{
		loadedSceneCounter++;
		Debug.Log ("scene loaded "+loadedSceneCounter);
	}
}
