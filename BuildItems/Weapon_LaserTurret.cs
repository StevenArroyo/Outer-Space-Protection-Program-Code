using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_LaserTurret : MonoBehaviour {

	private Transform target;

	[Header("General")]
	public float range;

	[Header("Use Bullets (default)")]
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPrefab;

	[Header("User Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public float damageOverTime;

	[Header("Unity Setup Fields")]
	public float turnSpeed = 10f;
	public Transform partToRotate;
	

	public string airEnemyTag = "AirEnemy";
   

	public Transform firePoint;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

		audioSource = gameObject.GetComponent<AudioSource>();

	}

	void UpdateTarget () {


		GameObject[] airEnemy = GameObject.FindGameObjectsWithTag(airEnemyTag);

        float shortestDistanceAir = Mathf.Infinity;
        GameObject nearestAir = null;
        foreach (GameObject air in airEnemy)
        {

            float distanceToAir = Vector3.Distance(transform.position, air.transform.position);

            if (distanceToAir < shortestDistanceAir)
            {

                shortestDistanceAir = distanceToAir;
                nearestAir = air;

            }
        }

        if (nearestAir != null && shortestDistanceAir <= range)
        {

            target = nearestAir.transform;
        }
        else
        {

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
					audioSource.Stop ();
				}
			}

			return;

		}

		LockOnTarget ();


		if (useLaser) {

			Laser ();

		} else {


			if (fireCountdown <= 0f) {

				Shoot ();
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

		target.GetComponent<EnemyHealth> ().TakeDamage (damageOverTime * Time.deltaTime);


		if (!lineRenderer.enabled) {

			lineRenderer.enabled = true;
			impactEffect.Play ();
			audioSource.Play ();
		}

			lineRenderer.SetPosition (0, firePoint.position);
			lineRenderer.SetPosition (1, target.position);

		Vector3 dir = firePoint.position - target.position;

		impactEffect.transform.position = target.position + dir.normalized * .48f;

		impactEffect.transform.rotation = Quaternion.LookRotation(dir);

	}

	void Shoot () {

		GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		TurretBullet bullet = bulletGO.GetComponent<TurretBullet> ();

		if (bullet != null)
			bullet.Seek(target);


	}

	void OnDrawGizmosSelected () {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);

	}

}
