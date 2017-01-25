using UnityEngine;
using System.Collections;

public class FireballMotion : MonoBehaviour {

	public float Speed = 100;
	public float force = 5.0f;

	private Vector3 acceleration;
	private Vector3 velocity;
	// Use this for initialization
	void Start () {
		acceleration.Set (Speed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		velocity += acceleration * Time.deltaTime;
		Vector3 displacement = velocity * Time.deltaTime;
		gameObject.transform.position += displacement;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Rock rock = other.GetComponent<Rock>();
		if (rock)
		{
			rock.Push(transform.position, force);
		}

		Debug.Log ("Fireball: " + other.name);
		Destroy(gameObject);
	}
}
