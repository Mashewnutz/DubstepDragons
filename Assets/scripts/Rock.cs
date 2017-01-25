using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	public void Push(Vector3 from, float force)
	{
		rigidbody2D.AddForce((transform.position - from) * force);
		rigidbody2D.AddTorque(force);
	}
}
