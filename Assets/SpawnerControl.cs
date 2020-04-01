using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] food;
	int randomSpawnPoint, randomFood;
	

	// Use this for initialization
	void Start()
	{
		
		InvokeRepeating("SpawnFood", 1f, 5f);
	}

	void SpawnFood()
	{
		randomSpawnPoint = Random.Range(0, spawnPoints.Length);
		randomFood = Random.Range(0, food.Length);
		Instantiate(food[randomFood], spawnPoints[randomSpawnPoint].position,
				Quaternion.identity);
		
	}

}
