using UnityEngine;

public class TurretRocket : MonoBehaviour {

	private Transform target;

	public float speed = 70f;
	public float blastRadius = 0f;

	public GameObject impactEffect;

	public float damage;

	private float startDamage = 25f;


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

	void OnDrawGizmoSelected () {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, blastRadius);

	}

	void HitTarget () {

		GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 2f);

		Debug.Log ("Rocket Hit Enemy");

		if (blastRadius > 0f) {

			Explode ();

		} else {

			Damage (target);

		}
		Destroy (gameObject);

	}

	void Explode () {

		Collider [] colliders = Physics.OverlapSphere (transform.position, blastRadius);
		foreach (Collider collider in colliders) {

			if (collider.tag == "Enemy") {

				Damage (collider.transform);

			}
				
		}

	}

	void Damage (Transform enemy) {

		target.GetComponent<EnemyHealth> ().TakeDamage(damage);

	}

	public void UpgradeDamage (float amount) {

		startDamage += amount;

		return;
	
	}		
}
