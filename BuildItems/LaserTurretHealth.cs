using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserTurretHealth : MonoBehaviour {


	public float startHealth = 100f;
	public float currentHealth;
	public float repairCost = 250f;
	public float damageOverTime = 0.25f;
	private float damage;

	private SoulHolder accessSouls;
	private float soulCount;

	private Text repairText;
	public Image turretHealthBar;

	// Use this for initialization
	void Start () {

		accessSouls = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();

		currentHealth = startHealth;

		repairText.text = ("");
		
	}

	void Update () {

		repairText = GameObject.FindWithTag("RepairText").GetComponent<Text>();

		damage = damageOverTime * Time.deltaTime;

		currentHealth -= damage;

		if (currentHealth <= 0) {

			Destroy (gameObject);

		}

		turretHealthBar.fillAmount = currentHealth / startHealth;
		soulCount = accessSouls.souls;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

		if ((other.tag == "Player") && (currentHealth < startHealth)) {

			repairText.text = ("Press Space to Repair Turret" + "\n" + "Cost: 250 Souls");

			Debug.Log ("Player Entered!");

		

		}

	}
	void OnTriggerStay (Collider other) {

		if ((other.tag == "Player") && (Input.GetKeyDown(KeyCode.Space)) && (currentHealth < startHealth) && (soulCount >= repairCost)){

			currentHealth = startHealth;

			accessSouls.GetComponent<SoulHolder>(). ReduceSouls (repairCost);

			Debug.Log ("Turret Repaired");


		}

		if (currentHealth == startHealth) {

			repairText.text = ("");

		}

	}

	void OnTriggerExit (Collider other) {

		if (other.tag == "Player") {

			repairText.text = ("");
		}

	}

}
