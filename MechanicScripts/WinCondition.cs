using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

public GameObject finalDrop;
private EnemyHealth accessHealth;
private float eHealth;

	// Use this for initialization
	void Start () {

		accessHealth = GameObject.Find("Demon Boss").GetComponent<EnemyHealth>();
		eHealth = accessHealth.health;
	}
	
	// Update is called once per frame
	void Update () {

		if (!finalDrop.activeSelf){

		GameObject.FindWithTag("Spawner").GetComponent<EnemyWaveSpawner_SS>().WinScreen();

		}

		
	}
}
