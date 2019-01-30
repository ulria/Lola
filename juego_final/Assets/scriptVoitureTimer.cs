using UnityEngine;
using System.Collections;

public class scriptVoitureTimer : MonoBehaviour {
	public static scriptVoitureTimer i;

	void Awake () {
		if(!i) {
			i = this;
			DontDestroyOnLoad(gameObject);
		}else 
			Destroy(gameObject);
	}
}