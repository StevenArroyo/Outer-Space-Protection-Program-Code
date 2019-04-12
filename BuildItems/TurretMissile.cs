using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMissile : MonoBehaviour {

	private Transform target;

	public float speed = 70f;

	public GameObject impactEffect;

	public float damage;


	public void Seek (Transform _target) {

		target = _target;


	}
	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {

		if (target == null) {

			Destroy (gameObject);
			return;

		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {

			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);

	}

	void HitTarget () {

		GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 2f);

		target.GetComponent<EnemyHealth> ().TakeDamage(damage);
        


        Debug.Log ("STA Hit Enemy");

		Destroy (gameObject);

	}


}
