using UnityEngine;
using System.Collections;

public class BabyDragonSpawner : MonoBehaviour {

	public Gauge gauge;
	public Marker marker;
	public Dragon dragon;

	public float lastHandledTemperature;

	void Start()
	{
		if (gauge == null)
			gauge = FindObjectOfType(typeof(Gauge)) as Gauge;
		if (marker == null)
			marker = FindObjectOfType(typeof(Marker)) as Marker;
		if (dragon == null)
			dragon = FindObjectOfType(typeof(Dragon)) as Dragon;
	}


	void Update()
	{
		if (Mathf.Abs(gauge.GetCurrentTemperature() - marker.GetMarkerPosition()) < 0.099f &&
		    lastHandledTemperature != gauge.GetDesiredTemperature())
		{
			dragon.SpawnBabyDragon(true);
			lastHandledTemperature = gauge.GetDesiredTemperature();
		}
	}	
}
