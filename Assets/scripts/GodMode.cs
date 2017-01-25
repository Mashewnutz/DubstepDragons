using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour 
{
	Dragon dragon;

	void Start()
	{
		if (dragon == null) dragon = FindObjectOfType(typeof(Dragon)) as Dragon;
		guiTexture.color = new Color(0.3f, 0.3f, 0.3f);
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && guiTexture.HitTest(Input.mousePosition))
		{
			dragon.ToggleGodMode();

			if (dragon.IsInGodMode())
				guiTexture.color = new Color(0.0f, 1.0f, 0.0f);
			else
				guiTexture.color = new Color(0.3f, 0.3f, 0.3f);
		}
	}
}
