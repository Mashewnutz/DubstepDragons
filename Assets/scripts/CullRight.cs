using UnityEngine;
using System.Collections;

public class CullRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Camera.main.WorldToScreenPoint (gameObject.transform.position).x - Camera.main.WorldToScreenPoint (Camera.main.transform.position).x;
		if (distance > Screen.width * 0.6) 
		{
			Destroy(gameObject);
		}
	}
}
