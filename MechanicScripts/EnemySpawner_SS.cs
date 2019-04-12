//Scott Schubr
//January 7th, 2018
//Use of tutorials through Brackeys and Renaissance of Coders.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_SS : MonoBehaviour {


    public GameObject enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
	}
	
	public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }


}
