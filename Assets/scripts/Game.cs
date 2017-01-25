using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public Dragon dragon;
	public Background background;
	public World world;
	public GameOver gameOverPrefab;
	
	public GameObject shootPrefab;
	public GameObject shoot;

	void Start()
	{
		dragon = FindObjectOfType(typeof(Dragon)) as Dragon;
		world = FindObjectOfType(typeof(World)) as World;
		background = FindObjectOfType(typeof(Background)) as Background;
	}

	public void DisplayTapToShoot()
	{
		shoot = Instantiate(shootPrefab) as GameObject;
	}

	public void DestroyTapToShoot()
	{
		if (shoot)
		{
			Destroy (shoot);
			shoot = null;
		}
	}

	public void Collided()
	{
		DestroyTapToShoot();
		--dragon.lives;
		if (dragon.lives == 0)
		{
			dragon.GameOver();
			GameOver gameOver = Instantiate(gameOverPrefab) as GameOver;
			gameOver.CreateBabyDragons(dragon.spawnedBabyDragons);
		}
		else
		{
			Camera.main.transform.position = new Vector3(1.902499f, -2.826332f);
			dragon.Spawn();
			world.DestroyWorld();
			background.DestroyBackgrounds();
		}
	}
}
