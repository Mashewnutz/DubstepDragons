using UnityEngine;
using System.Collections;

public class DragonHealth : MonoBehaviour {

	public float temperature = 0.0f;
	public float mark = 0.0f;
	public float newMarkDistance = 0.4f;
	public float increment = 0.2f;

	void Start() {
		GenerateNewMarkPosition();
	}

	public void IncreateTemperature()
	{
		temperature = Mathf.Min(temperature + increment, 1.0f);
	}

	public void DecreaseTemperature()
	{
		temperature = Mathf.Max (temperature - increment, -1.0f);
	}

	public void GenerateNewMarkPosition()
	{
		float offset = (Random.Range (0.0f, 1.0f) < 0.5f) ? newMarkDistance : -newMarkDistance;
		if (Mathf.Abs(mark + offset) > 1)
		{
			offset = -offset;
		}

		mark += offset; 
	}

	public float GetTemperature()
	{
		return Mathf.Clamp(temperature, -1.0f, 1.0f);
	}

	public float GetMarkPosition()
	{
		return Mathf.Clamp(mark, -1.0f, 1.0f);
	}


}
