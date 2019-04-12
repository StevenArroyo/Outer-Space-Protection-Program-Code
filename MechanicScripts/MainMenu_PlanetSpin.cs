using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_PlanetSpin : MonoBehaviour {

	public float speed = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.up, speed * Time.deltaTime);
		
	}
}
