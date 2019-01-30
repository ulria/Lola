using UnityEngine;
using System.Collections;

public class clickCounterHairDryer : MonoBehaviour {

	public int clickCounter = 0;
	public bool success = false;

	public GameObject timerGameObject;
	public timer timerScript;

	void Awake () {
		timerGameObject = GameObject.FindGameObjectWithTag ("Timer");
		timerScript = timerGameObject.GetComponent<timer> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (success) {
			ChangeColor ();
			GameObject.Find("GlobalCounter").GetComponent<GlobalCounterScript>().numberSuccessfulLevels++;
			timerScript.ChangeLevel ();
		}
	}

	void OnMouseDown()
	{
		clickCounter++;
	}

	void ChangeColor()
	{
		GetComponent<SpriteRenderer> ().color = new Color(171f, 201f, 255f, 255f);
	}
}
