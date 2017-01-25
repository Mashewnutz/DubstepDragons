using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {

	public GameObject babyDragonPrefab;
	public float distance = 20.0f;
	public float angle = 0.0f;
	public float rotateSpeed = 1.0f;

	List<GameObject> babyDragons = new List<GameObject>();

//	void Start()
//	{
//		CreateBabyDragons(5);
//	}

	public void CreateBabyDragons(int count)
	{
		Debug.Log ("CreateBabyDragons: " + count);
		for (int i = 0; i < count; ++i)
		{
			GameObject babyDragon = Instantiate(babyDragonPrefab) as GameObject;
			babyDragons.Add(babyDragon);
			babyDragon.transform.parent = transform;
		}
	}

	void Update()
	{
		angle += rotateSpeed * Time.deltaTime;

		float step = 360.0f / babyDragons.Count;
		for (int i = 0; i < babyDragons.Count; ++i)
		{
			UpdateDragon(babyDragons[i], angle + step * i);
		}
	}

	void UpdateDragon(GameObject dragon, float angle)
	{
		dragon.transform.position = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad) * distance + Camera.main.transform.position.x,
		                                        Mathf.Cos(angle * Mathf.Deg2Rad) * distance * 0.5f + Camera.main.transform.position.y);
	}
}
