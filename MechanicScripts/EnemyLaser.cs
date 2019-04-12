using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour {

	private Transform target;
    public GameObject lRendender;


	[Header("General")]
	public float range;

	private float startRange = 15f;


	[Header("Use Bullets (default)")]
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPrefab;

	[Header("User Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public float damageOverTime;

	private float startdamageOverTime = 30f;


	[Header("Unity Setup Fields")]
	public float turnSpeed = 10f;
	public Transform partToRotate;
	public string baseTag = "MainBase";

	public Transform firePoint;

	// Use this for initialization
	void Start () {

		damageOverTime = startdamageOverTime;
		range = startRange;

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}

	void UpdateTarget () {

		GameObject[] bases = GameObject.FindGameObjectsWithTag (baseTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestBase = null;
		foreach (GameObject Base in bases) {

			float distanceToBase = Vector3.Distance (transform.position, Base.transform.position);

			if (distanceToBase < shortestDistance) {

				shortestDistance = distanceToBase;
				nearestBase = Base;

			}
		}

		if (nearestBase != null && shortestDistance <= range) {

			target = nearestBase.transform;
		} else {

			target = null;

		}
	}

	// Update is called once per frame
	void Update () {

		if (target == null) {

			if (useLaser) {

				if (lineRenderer.enabled) {

					lineRenderer.enabled = false;
					impactEffect.Stop ();
				}
			}

			return;

		}

		LockOnTarget ();


		if (useLaser) {

			Laser ();

		} else {


			if (fireCountdown <= 0f) {

				//Shoot ();
				fireCountdown = 1f / fireRate;

			}

			fireCountdown -= Time.deltaTime;
		}
	}

	void LockOnTarget () {

		//Target Lock-On
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);


	}

	void Laser () {

		//target.GetComponent<BaseHealth> ().TakeDamage (damageOverTime * Time.deltaTime);


		if (!lineRenderer.enabled) {

            lRendender.SetActive(true);

			lineRenderer.enabled = true;
			impactEffect.Play ();
		}

			lineRenderer.SetPosition (0, firePoint.position);
			lineRenderer.SetPosition (1, target.position);

		Vector3 dir = firePoint.position - target.position;

		impactEffect.transform.position = target.position + dir.normalized * 1f;

		impactEffect.transform.rotation = Quaternion.LookRotation(dir);

	}

	void OnDrawGizmosSelected () {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);

	}

}
