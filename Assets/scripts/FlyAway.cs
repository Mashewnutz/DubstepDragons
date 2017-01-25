using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour {

	public float xSpeed = 8.0f;
	public float ySpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ySpeed *= (1.0f + Time.deltaTime);

		transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime,
		                                 transform.position.y + ySpeed * Time.deltaTime);

		if (Mathf.Abs(transform.position.x - Camera.main.transform.position.x) > 30.0f)
			Destroy(gameObject);
	}
}
