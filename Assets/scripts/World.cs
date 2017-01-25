using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour 
{
	public GameObject[] topRocksPrefabs;
	public GameObject[] midRocksPrefabs;
	public GameObject[] bottomRocksPrefabs;
	public GameObject groundPrefab;
	public GameObject[] orbsPrefab;
	public int rockCount = 10;
	public int orbCount = 10;
	public int ymax = 5;
	public float noiseSize = 0.4f;
	public float screenWidth = 20.0f;

	public float bottomRocksPosition = -3.5f;
	public float bottomRocksSpace = 3.0f;
	public float topRocksPosition = 3.5f;
	public float topRocksSpace = 3.0f;
	public float midRocksPosition = -2;
	public float midRocksSpace = 3.0f;
	public float midRocksSpaceY = 1.5f;
	public float groundSpace = 13.6f;
	public float groundPosition = -4.5f;
	public float orbsSpace = 6.0f;
	public float orbsSpaceY = 3.5f;

	public List<GameObject> bottomRocks = new List<GameObject>();
	public List<GameObject> topRocks = new List<GameObject>();
	public List<GameObject> midRocks = new List<GameObject>();
	public List<GameObject> grounds = new List<GameObject>();
	public List<GameObject> orbs = new List<GameObject>();

	public float nextTopRockAt;
	public float nextMidRockAt = 20;
	public float nextBottomRockAt;
	public float nextGroundAt;
	public float nextOrbAt = 10;

	private int lastTopRockIndex = 0;
	private int lastMidRockIndex = 0;
	private int lastBottomRockIndex = 0;

	void Update()
	{
		CreateObjects(Camera.main.transform.position.x + screenWidth);
	}

	void CreateObjects(float at)
	{
		while (nextTopRockAt < at)
		{
			int index = PickIndex(topRocksPrefabs.Length, lastTopRockIndex);
			lastTopRockIndex = index;
			GameObject topRock = topRocksPrefabs[index];

			GameObject rock = Instantiate(topRock) as GameObject;
			rock.transform.position = new Vector3(nextTopRockAt, topRocksPosition) + Noise();
			rock.transform.parent = transform;
			
			nextTopRockAt = rock.transform.position.x + topRocksSpace;
			
			topRocks.Add(rock);
		}
		
		while (nextMidRockAt < at)
		{
			int index = PickIndex(midRocksPrefabs.Length, lastMidRockIndex);
			lastMidRockIndex = index;
			GameObject midRock = midRocksPrefabs[index];

			GameObject rock = Instantiate(midRock) as GameObject;
			rock.transform.position = new Vector3(nextMidRockAt, midRocksPosition + Random.Range (-midRocksSpaceY, midRocksSpaceY)) + Noise();
			rock.transform.parent = transform;
			nextMidRockAt = rock.transform.position.x + midRocksSpace;
			midRocks.Add(rock);

		}
		
		while (nextBottomRockAt < at)
		{
			int index = PickIndex(bottomRocksPrefabs.Length, lastBottomRockIndex);
			lastBottomRockIndex = index;
			GameObject bottomRock = bottomRocksPrefabs[index];

			GameObject rock = Instantiate(bottomRock) as GameObject;
			rock.transform.position = new Vector3(nextBottomRockAt, bottomRocksPosition) + Noise();
			rock.transform.parent = transform;
			bottomRocks.Add(rock);
			
			nextBottomRockAt = rock.transform.position.x + bottomRocksSpace;
		}

		while (nextGroundAt < at)
		{
			GameObject ground = Instantiate(groundPrefab) as GameObject;
			ground.transform.position = new Vector3(nextGroundAt, groundPosition);
			ground.transform.parent = transform;
			grounds.Add (ground);
			nextGroundAt = ground.transform.position.x + groundSpace;
		}

		while (nextOrbAt < at)
		{
			Vector3 position;
			int tries = 0;
			do {
				position = new Vector3(nextOrbAt, Random.Range (-orbsSpaceY, orbsSpaceY)) + Noise();
				if (++tries >= 10)
					break;
			} while(Physics2D.OverlapCircle(position, 2.0f) != null);

			GameObject orb = Instantiate(PickOne(orbsPrefab)) as GameObject;
			orb.transform.position = position;
			orb.transform.parent = transform;
			orbs.Add(orb);
			nextOrbAt = orb.transform.position.x + bottomRocksSpace;
		}
	}
	
	[ContextMenu("DestroyWorld")]
	public void DestroyWorld()
	{
		DestroyTopRocks();
		DestroyMidRocks();
		DestroyBottomRocks();
		DestroyGrounds();
		DestroyOrbs();

		nextTopRockAt = 0;
		nextMidRockAt = 20;
		nextBottomRockAt = 0;
		nextGroundAt = 0;
		nextOrbAt = 10;	
	}

	[ContextMenu("RecreateWorld")]
	void RecreateWorld()
	{
		RecreateTopRocks();
		RecreateMidRocks();
		RecreateBottomRocks();
	}

	[ContextMenu("RecreateTopRocks")]
	void RecreateTopRocks()
	{
		DestroyTopRocks();
		CreateTopRocks();
	}
	
	// [ContextMenu("DestroyTopRocks")]
	void DestroyTopRocks()
	{
		for (int i = 0; i < topRocks.Count; ++i)
		{
			if (topRocks[i] != null)
				Destroy(topRocks[i]);
		}
		topRocks.Clear();
	}

	void DestroyGrounds()
	{
		for (int i = 0; i < grounds.Count; ++i)
		{
			if (grounds[i] != null)
				Destroy(grounds[i]);
		}
		grounds.Clear();
	}

	void DestroyOrbs()
	{
		for (int i = 0; i < orbs.Count; ++i)
		{
			if (orbs[i] != null)
				Destroy(orbs[i]);
		}
		orbs.Clear();
	}

	// [ContextMenu("CreateTopRocks")]
	void CreateTopRocks()
	{
		for (int i = 0; i < rockCount; ++i)
		{
			GameObject rock = Instantiate(PickOne(topRocksPrefabs)) as GameObject;
			rock.transform.position = new Vector3(i * topRocksSpace, topRocksPosition) + Noise();
//			lastTopRockPosition = rock.transform.position.x;
			rock.transform.parent = transform;
			topRocks.Add(rock);
		}
	}
	[ContextMenu("RecreateMidRocks")]
	void RecreateMidRocks()
	{
		DestroyMidRocks();
		CreateMidRocks();
	}
	
	// [ContextMenu("DestroyMidRocks")]
	void DestroyMidRocks()
	{
		for (int i = 0; i < midRocks.Count; ++i)
		{
			if (midRocks[i] != null)
				Destroy(midRocks[i]);
		}
		midRocks.Clear();
	}
	
	// [ContextMenu("CreateMidRocks")]
	void CreateMidRocks()
	{
		for (int i = 0; i < rockCount; ++i)
		{
			GameObject rock = Instantiate(PickOne(midRocksPrefabs)) as GameObject;
			rock.transform.position = new Vector3(i * midRocksSpace, Random.Range (-midRocksSpaceY, midRocksSpaceY)) + Noise();
			rock.transform.parent = transform;
//			lastMidRockPosition = rock.transform.position.x;
			midRocks.Add(rock);
		}
	}

	[ContextMenu("RecreateBottomRocks")]
	void RecreateBottomRocks()
	{
		DestroyBottomRocks();
		CreateBottomRocks();
	}

	// [ContextMenu("DestroyBottomRocks")]
	void DestroyBottomRocks()
	{
		for (int i = 0; i < bottomRocks.Count; ++i)
		{
			if (bottomRocks[i] != null)
				Destroy(bottomRocks[i]);
		}
		bottomRocks.Clear();
	}

	// [ContextMenu("CreateBottomRocks")]
	void CreateBottomRocks()
	{
		for (int i = 0; i < rockCount; ++i)
		{
			GameObject rock = Instantiate(PickOne(bottomRocksPrefabs)) as GameObject;
			rock.transform.position = new Vector3(i * bottomRocksSpace, bottomRocksPosition) + Noise();
			rock.transform.parent = transform;
//			lastBottomRockPosition = rock.transform.position.x;
			bottomRocks.Add(rock);
		}
	}
	
	GameObject PickOne(GameObject[] gameObjects)
	{
		return gameObjects[Random.Range(0, gameObjects.Length)];
	}

	int PickIndex(int range, int excludeIndex)
	{
		int index = Random.Range (0, range);
		while (index == excludeIndex) {
			index = Random.Range (0, range);
		}
		return index;
	}

	GameObject PickOrb()
	{
		return orbsPrefab[Random.Range(0, orbsPrefab.Length)];
	}

	Vector3 Noise()
	{
		return new Vector3(Random.Range(-noiseSize, noiseSize),
		                   Random.Range(-noiseSize, noiseSize),
		                   Random.Range(-noiseSize, noiseSize));
	}
}
