using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {

	public GameObject prefabs;
	public List<GameObject> backgrounds = new List<GameObject>();
	public float scrollSpeed = 1.0f;
	public float backgroundSpace = 24.12601f;
	public Dragon dragon;

	void Start()
	{
		dragon = FindObjectOfType(typeof(Dragon)) as Dragon;
	}

	public void DestroyBackgrounds()
	{
		foreach (GameObject go in backgrounds)
			Destroy(go);
		backgrounds.Clear();
	}

	void Update () {
		if (dragon.lives <= 0)
			return;

		foreach(GameObject go in backgrounds)
		{
			go.transform.position = new Vector3(go.transform.position.x + scrollSpeed * Time.deltaTime, 0.0f);
		}

		SpawnNewBackground(Camera.main.transform.position.x + backgroundSpace);
	}

	void SpawnNewBackground(float at)
	{
		float nextBackgroundAt = backgrounds.Count > 0 ? backgrounds[backgrounds.Count - 1].transform.position.x : -backgroundSpace;
		while (nextBackgroundAt < at)
		{
			GameObject background = Instantiate(prefabs) as GameObject;
			background.transform.position = new Vector3(nextBackgroundAt + backgroundSpace, 0);
			background.transform.parent = transform;
			backgrounds.Add(background);

			nextBackgroundAt += background.transform.position.x + backgroundSpace;
		}
	}
}
