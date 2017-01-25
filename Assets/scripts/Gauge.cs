using UnityEngine;
using System.Collections;

public class Gauge : MonoBehaviour {

	public DragonHealth dragonHealth;
	public GUITexture insideIce;
	public GUITexture insideHot;
	public float maxHeight = 190.0f;
	private Rect originalSizeIce;
	private Rect originalSizeHot;

	private float currentTemperature;
	public float updateSpeed = 1.0f;

	public float GetCurrentTemperature()
	{
		return currentTemperature;
	}

	public float GetDesiredTemperature()
	{
		return dragonHealth.GetTemperature();
	}

	void Start()
	{
		if (dragonHealth == null)
		{
			dragonHealth = GameObject.FindObjectOfType(typeof(DragonHealth)) as DragonHealth;
		}

		originalSizeIce = insideIce.pixelInset;
		originalSizeHot = insideHot.pixelInset;
		insideIce.pixelInset = new Rect(originalSizeIce.x, originalSizeIce.y, originalSizeIce.width, 0.0f);
		insideHot.pixelInset = new Rect(originalSizeHot.x, originalSizeHot.y, originalSizeHot.width, 0.0f);
	}

	void Update () {
		float nextPosition = dragonHealth.GetTemperature();
		if (nextPosition > currentTemperature)
			currentTemperature += Mathf.Min (updateSpeed * Time.deltaTime, nextPosition - currentTemperature);
		else if (nextPosition < currentTemperature)
			currentTemperature -= Mathf.Min (updateSpeed * Time.deltaTime, currentTemperature - nextPosition);
		SetTemperature();
	}

	void SetTemperature()
	{
		float offset = maxHeight * currentTemperature;

		insideIce.pixelInset = new Rect(originalSizeIce.x, -offset, 
		                                originalSizeIce.width, maxHeight + offset);
		insideHot.pixelInset = new Rect(originalSizeHot.x, -maxHeight, 
		                                originalSizeHot.width, maxHeight - offset);
	}
}
