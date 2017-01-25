using UnityEngine;
using System.Collections;

public class FollowDragon : MonoBehaviour {

	public Dragon dragon;
	public GameObject fireballPrefab;
	public Vector3 offset;
	public Vector3 acceleration;
	public Vector3 velocity;
	public float strength = 10.0f;
	int ammo = 3;
	// Use this for initialization
	void Start () {
		ammo = 3;
		offset = new Vector3 (1, 0, 0);
		dragon = FindObjectOfType (typeof(Dragon)) as Dragon;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && Input.mousePosition.x > Screen.width*0.5) {
			ShootFireball();
		}
	}


	void ShootFireball()
	{
		GameObject fireball = Instantiate (fireballPrefab) as GameObject;
		fireball.transform.position = gameObject.transform.position;
		ammo--;
		Debug.Log("Decreasing ammo:" + ammo);
		if (ammo == 0 && dragon != null) 
		{

			BabyDragonTrail trail = dragon.GetComponent<BabyDragonTrail>();
			if(trail != null && gameObject != null){
				trail.babyDragons.Remove(gameObject);
			}
			DestroyObject(gameObject);
		}
	}
}
