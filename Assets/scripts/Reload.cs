using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour 
{
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && GetComponent<GUITexture>().HitTest(Input.mousePosition))
		{
			Application.LoadLevel(0);
		}
	}
}
