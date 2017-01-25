using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour 
{
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && guiTexture.HitTest(Input.mousePosition))
		{
			Application.LoadLevel(0);
		}
	}
}
