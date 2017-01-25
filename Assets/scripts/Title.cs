using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	public float size = 0.0f;
	public float speed = 1.0f;
	public float maxSize = 40.0f;

	// Update is called once per frame
	void Update () {
		size += speed * Time.deltaTime;
		transform.localScale = new Vector3(size, size, 1.0f);

		if (size > maxSize || Input.GetMouseButtonDown(0))
			Application.LoadLevel(1);
	}
}
