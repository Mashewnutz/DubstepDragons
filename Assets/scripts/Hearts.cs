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
		hearts[0].guiTexture.enabled = dragon.lives >= 1;
		hearts[1].guiTexture.enabled = dragon.lives >= 2;
		hearts[2].guiTexture.enabled = dragon.lives >= 3;
	}
}
