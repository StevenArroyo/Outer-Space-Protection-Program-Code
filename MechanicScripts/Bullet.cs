using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float range;

	private float startRange = 0.3f;

	public GameObject hitFX;

	void Start () {

		range = startRange;

	}

	void Update () {

		range = startRange;


	}

	void OnTriggerEnter (Collider other) 
    {
		if (other.tag == "AirEnemy") {

			GameObject effectIns = (GameObject)Instantiate (hitFX, transform.position, transform.rotation);
			Destroy (effectIns, 2f);

			Destroy (gameObject);

		} else {

			Destroy (gameObject, range);

		}

        if (other.tag == "Boss")
        {

            GameObject effectIns = (GameObject)Instantiate(hitFX, transform.position, transform.rotation);
            Destroy(effectIns, 2f);

            Destroy(gameObject);

        }
        else
        {

            Destroy(gameObject, range);

        }

    }

	public void UpgradeRange (float amount) {

		range += amount;
		startRange +=amount;

	}
}
