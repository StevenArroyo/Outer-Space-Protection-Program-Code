﻿using UnityEngine;

public class TurretBullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;

	public GameObject impactEffect;

	private float damage;

	public float startDamage = 10f;



	public void Seek (Transform _target) {

		target = _target;


	}
	// Use this for initialization
	void Start () {
		
		damage = startDamage;

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

		Destroy (gameObject);

	}

}
