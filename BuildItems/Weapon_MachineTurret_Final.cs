using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_MachineTurret_Final : MonoBehaviour {

	private Transform target;


	[Header("Attributes")]
	public float range;
	private float startRange = 15f;
	public float fireRate;
	private float startRate = 10f;
	private float fireCountdown = 0f;

	[Header("Unit Setup Field")]
	public float turnSpeed = 10f;

	public Transform partToRotate;

    public string bossTag = "FinalBoss";

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


	// Use this for initialization
	void Start () {



		range = startRange;
		fireRate = startRate;
	
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget () {


        GameObject[] fbosses = GameObject.FindGameObjectsWithTag(bossTag);

        float fshortestDistanceBoss = Mathf.Infinity;
        GameObject fnearestBoss = null;
        foreach (GameObject fboss in fbosses)
        {

            float fdistanceToBoss = Vector3.Distance(transform.position, fboss.transform.position);

            if (fdistanceToBoss < fshortestDistanceBoss)
            {

                fshortestDistanceBoss = fdistanceToBoss;
                fnearestBoss = fboss;

            }
        }

        if (fnearestBoss != null && fshortestDistanceBoss <= range)
        {

            target = fnearestBoss.transform;
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


		

		if (Input.GetKeyDown (KeyCode.O)) {

			Debug.Log (startRange);
			Debug.Log (startRate);

		}

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

	public void UpgradeFireRate (float amount) {

		startRate += amount;

		return;
	}

}
