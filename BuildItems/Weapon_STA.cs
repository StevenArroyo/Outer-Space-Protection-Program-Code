using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_STA : MonoBehaviour {

	private Transform target;

	[Header("Attributes")]
	public float range;
	private float startRange = 15f;
	public float fireRate;
	private float startFireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Unit Setup Field")]
	public float turnSpeed = 10f;

	public Transform partToRotate;
	public string enemyTag = "AirEnemy";

	public GameObject missilePrefab;
	public Transform firePoint;

	private AudioSource audioSource;

	public AudioClip shotSFX;

	// Use this for initialization
	void Start () {

		range = startRange;
		fireRate = startFireRate;

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

		audioSource = gameObject.GetComponent<AudioSource>();

	}

	void UpdateTarget () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {

			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);

			if (distanceToEnemy < shortestDistance) {

				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;

				Debug.Log ("Enemy Targeted!");

			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {

			target = nearestEnemy.transform;
		} else {

			target = null;

		}

    }

	// Update is called once per frame
	void Update () {

		if (target == null)
			return;

		//Target Lock-On
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);


		if (fireCountdown <= 0f) {

			Shoot ();
			fireCountdown = 1f / fireRate;

		}

		fireCountdown -= Time.deltaTime;
	}

	void Shoot () {

		GameObject missileGO = (GameObject) Instantiate (missilePrefab, firePoint.position, firePoint.rotation);
		TurretMissile missile = missileGO.GetComponent<TurretMissile> ();

		audioSource.PlayOneShot(shotSFX);

		if (missile != null)
			missile.Seek(target);


		Debug.Log ("Shoot!");

	}

	void OnDrawGizmosSelected () {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);

	}

	public void UpgradeRange (float amount) {

		startRange += amount;

		return;

	}

	public void UpgradeFireRate (float amount) {

		startFireRate += amount;

		return;

	}

}