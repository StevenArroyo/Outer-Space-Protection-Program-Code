using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitUpgrades : MonoBehaviour {

	public float clickCount;

	private float levelCount = 1f;

	public Text levelText;

	public GameObject upgradeButton;

	private SoulHolder accessSoul;
	private float soulCount;

	public Text rangeUpgrade;
	public Text rateUpgrade;
	public Text damageUpgrade;
	public Text healthUpgrade;


	// Use this for initialization
	void Start () {

		clickCount = 0f;

	}
	
	// Update is called once per frame
	void Update () {

		accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
		soulCount = accessSoul.souls;

		if (clickCount == 5) {

			upgradeButton.SetActive (false);

			rangeUpgrade.text = "Maxed";
			rateUpgrade.text = "Maxed";
			damageUpgrade.text = "Maxed";
			healthUpgrade.text = "Maxed";

			levelText.color = Color.green;

			Debug.Log ("Fully Upgraded");



		}
		
	}
	//Upgrades Unit on Button Click/Increases Unit Level by 1
	public void IncreaseClickCount () {

		if (soulCount >= 1000) {

		clickCount += 1f;

		levelCount += 1f;

		levelText.text = "Lvl. " + levelCount.ToString ();

		Debug.Log ("Upgrade Complete");

		return;
		}
	}
}
