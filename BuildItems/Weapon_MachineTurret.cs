using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_MachineTurret : MonoBehaviour {

	private Transform target;


	[Header("Attributes")]
	public float range;
	public float fireRate;
	private float fireCountdown = 0f;

	[Header("Unit Setup Field")]
	public float turnSpeed = 10f;

	public Transform partToRotate;

    public string bossTag = "Boss";

    public GameObject bulletPrefab;
	public Transform firePoint;

		public float clickCount;

	private float levelCount = 1f;

	private Text levelText;

	private GameObject upgradeButton;

	private SoulHolder accessSoul;
	private float soulCount;

	private Text rangeUpgrade;
	private Text rateUpgrade;
	private Text damageUpgrade;
	private Text healthUpgrade;
	private AudioSource audioSource;
	public AudioClip shotSFX;


	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void UpdateTarget () {


        GameObject[] bosses = GameObject.FindGameObjectsWithTag(bossTag);

        float shortestDistanceBoss = Mathf.Infinity;
        GameObject nearestBoss = null;
        foreach (GameObject boss in bosses)
        {

            float distanceToBoss = Vector3.Distance(transform.position, boss.transform.position);

            if (distanceToBoss < shortestDistanceBoss)
            {

                shortestDistanceBoss = distanceToBoss;
                nearestBoss = boss;

            }
        }

        if (nearestBoss != null && shortestDistanceBoss <= range)
        {

            target = nearestBoss.transform;
        }
        else
        {

            target = null;

        }


    }
	
	// Update is called once per frame
	void Update () {

		accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
		soulCount = accessSoul.souls;



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

		GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		TurretBullet bullet = bulletGO.GetComponent<TurretBullet> ();

		audioSource.PlayOneShot(shotSFX);

		if (bullet != null)
			bullet.Seek(target);

	}

	void OnDrawGizmosSelected () {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);

	}

}
