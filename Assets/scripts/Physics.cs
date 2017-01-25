using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {

	public Vector3 acceleration;
	public Vector3 velocity;
	public float maxVelocity;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		velocity += acceleration * Time.deltaTime;
		float length = velocity.magnitude;
		if (length > maxVelocity) {
			velocity *= maxVelocity/length;
		}
		transform.position += velocity * Time.deltaTime;
	}
}
