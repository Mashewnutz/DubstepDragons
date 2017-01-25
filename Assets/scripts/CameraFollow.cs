using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject dragon;

	public Vector3 offset = Vector3.back;
	public float minScreen = -4.5f;
	public float maxScreen = 4.5f;
	
	void Update () {
		if (dragon == null)
		{
			dragon = (FindObjectOfType(typeof(DragonHealth)) as DragonHealth).gameObject;
		}

		transform.position = dragon.transform.position + offset;
		if (transform.position.y >= maxScreen) {
			transform.position = new Vector3(dragon.transform.position.x + offset.x, maxScreen, dragon.transform.position.z + offset.z);
		}

		if (transform.position.y <= minScreen) {
			transform.position = new Vector3(dragon.transform.position.x + offset.x, minScreen, dragon.transform.position.z + offset.z);
		}
	}
}
