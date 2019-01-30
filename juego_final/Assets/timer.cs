using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	private string[] levels = { "Main", "face", "hair", "liner", "Nails", "Perfume", "scenes"};
	private int level = 0;
	private int lastLevel;

	private Transform thisTransform;
	private float moveSpeed = 1.25f;

	//private bool isHome = false;
	private float newX = 0.0f;
	private float newY = 0.0f;
	private float newZ = 0.0f;
	private float dist = 7.5f;
	private Vector3 newPos;

	public GlobalCounterScript globalCounterScriptLocal;
	public int loadedSceneCounterLocal;
	private int maximumScenes = 7;

	private Random random = new Random();

	//public string[] scenes = { "scenes", "Main", "Nails", "face", "Perfume", "liner", "hair" };

	void Awake() {
		//DontDestroyOnLoad(this.transform.gameObject);
	}

	void Start()
	{
		Debug.Log("idx"+Application.loadedLevel);
		thisTransform = this.transform;
		//thisTransform.gameObject = scriptVoitureTimer.i;
		// 1. find GlobalCounter by using GameObject.Find()
		var globalCounterLocal = GameObject.Find("GlobalCounter");
		// 2. get a referece of GlobalCounter script from the game object from 1.
		globalCounterScriptLocal = globalCounterLocal.GetComponent<GlobalCounterScript>();
		// 3. access GlobalCounter script's loadedSceneCounter variable and multiply it to moveSpeed
		loadedSceneCounterLocal = globalCounterScriptLocal.loadedSceneCounter;
		lastLevel = globalCounterScriptLocal.lastLevel;
	}

	void Update () 
	{
		/*if(!isHome)
		{*/
			newX = thisTransform.position.x + (/*loadedSceneCounterLocal **/ moveSpeed * Time.deltaTime);
			newY = thisTransform.position.y;
			newZ = thisTransform.position.z;
			newPos = new Vector3(newX, newY, newZ);
			thisTransform.position = newPos;
		//}

		if (newX > dist) 
		{
			ChangeLevel ();
		}
	}

	public void ChangeLevel()
	{
		/*bool isAllTrue = true;
		for(int i = 0; i < globalCounterScriptLocal.scenesPlayedThisLoop.Length; i++)
		{
			Debug.Log ("globalCounterScriptLocal.scenesPlayedThisLoop [i] , " + i + " : " + globalCounterScriptLocal.scenesPlayedThisLoop [i]);
			if (!globalCounterScriptLocal.scenesPlayedThisLoop [i]) {
				isAllTrue = false;
			}
		}
		if(isAllTrue)
		{
			Debug.Log ("Reseting");
			for (int i = 0; i < globalCounterScriptLocal.scenesPlayedThisLoop.Length; i++)
			{
				globalCounterScriptLocal.scenesPlayedThisLoop [i] = false;
			}
		}*/
		Debug.Log ("scenesPlayedThisLoop[level] : " + globalCounterScriptLocal.scenesPlayedThisLoop [level]);
		if (loadedSceneCounterLocal < maximumScenes) {
			while ((level == lastLevel) || globalCounterScriptLocal.scenesPlayedThisLoop [level]) {
				level = Random.Range (0, 6);
			}
			globalCounterScriptLocal.lastLevel = level;
			globalCounterScriptLocal.scenesPlayedThisLoop [level] = true;

			//Application.LoadLevel(levels[level]);
			System.Threading.Thread.Sleep(1000);
			UnityEngine.SceneManagement.SceneManager.LoadScene(levels[level]);
			//UnityEngine.SceneManagement.SceneManager.LoadScene("hair");

			newX = -7.3f;
			newY = -5.5f;
			newZ = -0.62f;
			newPos = new Vector3(newX, newY, newZ);
			thisTransform.position = newPos;
		} else {
			Debug.Log ("Loading car");
			System.Threading.Thread.Sleep (1000);
			UnityEngine.SceneManagement.SceneManager.LoadScene ("car");
		}
	}
}
