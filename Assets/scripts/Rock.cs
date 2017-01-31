using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	public void Push(Vector3 from, float force)
	{
		GetComponent<Rigidbody2D>().AddForce((transform.position - from) * force);
		GetComponent<Rigidbody2D>().AddTorque(force);
	}
}
