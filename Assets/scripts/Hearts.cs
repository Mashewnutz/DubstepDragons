using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hearts : MonoBehaviour {

	public List<GameObject> hearts;
	public Dragon dragon;

	void Start()
	{
		dragon = FindObjectOfType(typeof(Dragon)) as Dragon;
	}

	void Update () {
		hearts[0].GetComponent<GUITexture>().enabled = dragon.lives >= 1;
		hearts[1].GetComponent<GUITexture>().enabled = dragon.lives >= 2;
		hearts[2].GetComponent<GUITexture>().enabled = dragon.lives >= 3;
	}
}
