using UnityEngine;
using System.Collections;

public class Nail : MonoBehaviour {

	public  GameObject nailHitEffect;

	public int nailCounter = 0;

	void Update()
	{
		
	}

	void OnMouseDown()
	{
		ChangeColor();
	}

	void ChangeColor ()
	{
		// 1. declare a public variable which will hold a particle effect prefab
		// 2. instantiate that prefab when the nail color changes

		if (GetComponent<SpriteRenderer> ().color == Color.red) 
		{
			GetComponent<SpriteRenderer> ().color = Color.magenta;
			GameObject.FindGameObjectWithTag("NailCounter").GetComponent<GlobalNailCounter>().nailCounter++;
		}
		else {
			if (GetComponent<SpriteRenderer> ().color == Color.magenta) 
			{
				GetComponent<SpriteRenderer> ().color = Color.red;
				GameObject.FindGameObjectWithTag("NailCounter").GetComponent<GlobalNailCounter>().nailCounter--;
			}
		}
	}
}
