using UnityEngine;
using System.Collections;

public class BabyDragonTrail : MonoBehaviour {

	public ArrayList babyDragons = new ArrayList();
	public GameObject fireballPrefab;
	public Vector3 offset;

	private Game game;

	void Start()
	{
		game = FindObjectOfType(typeof(Game)) as Game;
	}

	public void Clear()
	{
		foreach (GameObject go in babyDragons)
			Destroy(go);

		babyDragons.Clear();
	}

	// Update is called once per frame
	void Update () {
		int index = 0;
		foreach(GameObject babyDragon in babyDragons){
			Vector3 targetPos = transform.position;
			if(index > 0)
			{
				targetPos = (babyDragons[index-1] as GameObject).transform.position;
			}


			Vector3 direction = targetPos - babyDragon.transform.position;
			direction *= 4;

			Physics physics = babyDragon.GetComponent<Physics>();

			physics.velocity = direction;

			index++;
		}

		if (babyDragons.Count > 0)
		{
			foreach (Touch t in Input.touches)
			{
				if (t.phase == TouchPhase.Began && t.position.x > Screen.width*0.5) {
					ShootFireball(babyDragons[Random.Range(0, babyDragons.Count)] as GameObject);
				}
			}
		}
		if (Input.GetMouseButtonDown(2))
		{
			ShootFireball(babyDragons[Random.Range(0, babyDragons.Count)] as GameObject);
		}
	}

	void ShootFireball(GameObject baby)
	{
		game.DestroyTapToShoot();

		Ammo ammo = baby.GetComponent<Ammo> ();
		GameObject fireball = Instantiate (fireballPrefab) as GameObject;
		fireball.transform.position = baby.transform.position;
		ammo.count--;
		Debug.Log("Decreasing ammo:" + ammo);
		if (ammo.count == 0) 
		{			
			babyDragons.Remove(baby);
			baby.AddComponent<FlyAway>();
		}
	}
	

}
