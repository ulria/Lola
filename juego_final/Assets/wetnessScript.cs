using UnityEngine;
using System.Collections;

public class wetnessScript : MonoBehaviour {

	private int clicksToDry;
	private GameObject hairWetGameObject;
	private clickCounterHairDryer clickCounterScriptLocal;
	private int clickCounter;

	private int timesToDry;
	private int timesDriedCounter = 0;

	private float newX, newY, newZ;
	private Vector3 newPos;
	private Transform thisTransform;
	private float dist = 12.5f;
	private float moveSpeed = 15.0f;

	public GlobalCounterScript globalCounterScriptLocal;
	public int loadedSceneCounterLocal;

	// Use this for initialization
	void Start () {
		clicksToDry = Random.Range (1, 5);
		timesToDry = Random.Range (2, 4);

		hairWetGameObject = GameObject.FindGameObjectWithTag ("HairWet");
		clickCounterScriptLocal = hairWetGameObject.GetComponent<clickCounterHairDryer> ();

		Debug.Log("Compteur de click : " + clickCounter + "\t Clicks to dry : " + clicksToDry);


		thisTransform = this.transform;

		var globalCounterLocal = GameObject.Find("GlobalCounter");
		// 2. get a referece of GlobalCounter script from the game object from 1.
		globalCounterScriptLocal = globalCounterLocal.GetComponent<GlobalCounterScript>();
		// 3. access GlobalCounter script's loadedSceneCounter variable and multiply it to moveSpeed
		loadedSceneCounterLocal = globalCounterScriptLocal.loadedSceneCounter;

		//Instanciate la wetness
		//Apres un nombre random de clique sur les cheveux mouilles, faire partir la wetness
		//Recommencer (instanciate + clicks)
		//Apres un certain nombre de loops, les cheveux sont secs

		//Compteur de cliques sur les cheveux -> global, ce script doit aller le chercher
		// Le compteur est incrementer dans le script sur les cheveux mouilles
	}
	
	// Update is called once per frame
	void Update () {
		clickCounter = clickCounterScriptLocal.clickCounter;
		if(clickCounter >= clicksToDry) // might need to be >=
		{
			//Make the wetness go away
			newX = thisTransform.position.x + (loadedSceneCounterLocal * moveSpeed * Time.deltaTime);
			newY = thisTransform.position.y;
			newZ = thisTransform.position.z;
	
			//}

			if (newX > dist) {
				Debug.Log("Compteur de click : " + clickCounter + "\t Clicks to dry : " + clicksToDry);
				timesDriedCounter++;
				if(timesDriedCounter == timesToDry)
				{
					//Success -> skip to the next level
					//Reset clickCounter to 0 for next time we get this level
					Debug.Log("Success!");
					clickCounterScriptLocal.success = true;
				}else{
					newX = -2.4f;
					clicksToDry = Random.Range (5, 10);
					clickCounterScriptLocal.clickCounter = 0;
				}
				//else recommencer
			}
			newPos = new Vector3(newX, newY, newZ);
			thisTransform.position = newPos;
		}
	}
}
