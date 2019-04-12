using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoMachine : MonoBehaviour {

	public float waitTime;

	private float waitDelay = 30f;

	public GameObject ammoDrop;

	public Transform dropLocation;

	public Text currentTime;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("SpawnAmmo", waitTime, waitDelay);
		
	}
	
	// Update is called once per frame
	void Update () {

		currentTime.text = "Production Time: " + waitTime.ToString() + "s";

		
	}

	public void SpawnAmmo () {

		Instantiate (ammoDrop, dropLocation.position, dropLocation.rotation);

	}

	public void UpgradeDropTime (float amount) {

		waitTime -= amount;

	}
}
