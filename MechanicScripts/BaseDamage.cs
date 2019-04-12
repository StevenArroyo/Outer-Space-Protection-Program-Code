using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamage : MonoBehaviour {

	private float damageOverTime;

	private float startdamageOverTime = 50f;

	// Use this for initialization
	void Start () {
		
		damageOverTime = startdamageOverTime;

	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {

		if (other.tag == "location1") {

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().TakeDamage ();

		}

		if (other.tag == "location2") {

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().TakeDamage ();

		}

		if (other.tag == "location3") {

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().TakeDamage ();

		}

		if (other.tag == "location4") {

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().TakeDamage ();

		}

		if (other.tag == "location5") {

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().TakeDamage ();

		}

		if (other.tag == "location6") {

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().TakeDamage ();

		}

	}
}
