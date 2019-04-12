using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_LaserTurret_Soldier : MonoBehaviour {

	private Transform target;

	[Header("General")]
	public float range;

	private float startRange = 15f;


	[Header("Use Bullets (default)")]
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPrefab;

	[Header("User Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer_Solider;
	public ParticleSystem impactEffect;
	public float damageOverTime;

	private float startdamageOverTime = 5f;


	[Header("Unity Setup Fields")]
	public float turnSpeed = 10f;
	public Transform partToRotate;
	

	public string airEnemyTag = "AirEnemy";
   

	public Transform firePoint;

	// Use this for initialization
	void Start () {

		damageOverTime = startdamageOverTime;
		range = startRange;

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

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

				if (lineRenderer_Solider.enabled) {

					lineRenderer_Solider.enabled = false;
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

		target.GetComponent<EnemyHealth_Soldier> ().TakeDamage (damageOverTime * Time.deltaTime);


		if (!lineRenderer_Solider.enabled) {

			lineRenderer_Solider.enabled = true;
			impactEffect.Play ();
		}

			lineRenderer_Solider.SetPosition (0, firePoint.position);
			lineRenderer_Solider.SetPosition (1, target.position);

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

	public void UpgradeRange (float amount) {

		startRange += amount;

		return;

	}

	public void UpgradeDamage (float amount) {

		startdamageOverTime += amount;

		return;

	}

}
