using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	public float changeAt;
	public float frequency = 0.2f;

	// Use this for initialization
	void Start () {
		changeAt = Time.time + frequency;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > changeAt)
		{
			changeAt = Time.time + frequency;
			guiText.enabled = !guiText.enabled;
		}
	}
}
