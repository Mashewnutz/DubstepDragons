using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {
	public DragonHealth dragonHealth;
	public GUITexture inside;

	public float updateSpeed = 10.0f;

	private Rect originalSize;
	private float currentPosition;

	public float GetMarkerPosition()
	{
		return currentPosition;
	}

	void Start()
	{
		if (dragonHealth == null)
		{
			dragonHealth = GameObject.FindObjectOfType(typeof(DragonHealth)) as DragonHealth;
		}

		originalSize = inside.pixelInset;
	}

	void Update () {
		float nextPosition = dragonHealth.GetMarkPosition();
		if (nextPosition > currentPosition)
			currentPosition += Mathf.Min (updateSpeed * Time.deltaTime, nextPosition - currentPosition);
		else if (nextPosition < currentPosition)
			currentPosition -= Mathf.Min (updateSpeed * Time.deltaTime, currentPosition - nextPosition);
		SetPosition();
	}

	void SetPosition()
	{
		inside.pixelInset = new Rect(originalSize.x, (-currentPosition * 190.0f) - originalSize.height / 2, originalSize.width, originalSize.height);
	}
}
