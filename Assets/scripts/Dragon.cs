using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour {

	public DragonHealth dragonHealth;
	public BabyDragonTrail dragonTrail;
	public World world;
	public GameObject babyDragon;
	public int lives = 3;
	public int spawnedBabyDragons;
	public bool godMode = false;

	public Score score;

	void Start() {
		if (dragonHealth == null)
		{
			dragonHealth = GetComponent<DragonHealth>();
		}

		if (score == null)
		{
			score = FindObjectOfType(typeof(Score)) as Score;
		}

		dragonTrail = transform.parent.GetComponent<BabyDragonTrail>();
		Spawn();
	}

	public void GameOver()
	{
		KillBabes();
		GetComponent<SpriteRenderer>().enabled = false;
		DragonInput input = GetComponentInParent<DragonInput>();
		if (input)
			input.enabled = false;
	}

	public void Spawn()
	{
		transform.parent.position = new Vector3(1.902499f, -2.826332f);
		dragonTrail.Clear();
//		SpawnBabyDragon(false);
//		SpawnBabyDragon(false);
	}

	public void KillBabes()
	{
		dragonTrail.Clear();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "FireOrb") {
			if (score) score.AddScore(1);
			dragonHealth.DecreaseTemperature();
			DestroyObject(other.gameObject);
		}
		else if (other.tag == "IceOrb") {
			if (score) score.AddScore(1);
			dragonHealth.IncreateTemperature();
			DestroyObject(other.gameObject);
		}
		else if (other.tag == "Rock" && !godMode) {
			Game game = FindObjectOfType(typeof(Game)) as Game;
			if (game)
				game.Collided();
		}
    }

	public void ToggleGodMode()
	{
		godMode = !godMode;
	}

	public bool IsInGodMode()
	{
		return godMode;
	}

	public void SpawnBabyDragon(bool addScore)
	{
		if (spawnedBabyDragons == 0)
		{
			Game game = FindObjectOfType(typeof(Game)) as Game;
			game.DisplayTapToShoot();
		}

		++spawnedBabyDragons;

		GameObject baby = Instantiate(babyDragon) as GameObject;
		baby.transform.position = dragonHealth.transform.position;
		dragonTrail.babyDragons.Insert (0, baby);

		dragonHealth.GenerateNewMarkPosition();
		if (score && addScore) score.AddScore(10);
	}
}
