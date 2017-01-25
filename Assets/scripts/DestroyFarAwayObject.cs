using UnityEngine;
using System.Collections;

public class DestroyFarAwayObject : MonoBehaviour {

	public float screenWidth = 20.0f;
	// Update is called once per frame
	void Update () {
		if (transform.position.x - Camera.main.transform.position.x < -screenWidth)
		{
			Destroy(gameObject);
		}
	}
}
