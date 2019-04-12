using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurfacetoAir : MonoBehaviour {


	public Text buildText;
	public Text upgradeText;

	public Text firerateText;
	public Text firerateUpgrade;
	public Text rangeText;
	public Text rangeUpgrade;
	public Text damageText;
	public Text damageUpgrade;
	public Text healthText;
	public Text healthUpgrade;

	private GameShop accessShop;

	private float buildCost;
	private float upgradeCost;
	private float rateChange = 2f;
	private float currentRate = 1f;
	private float rangeChange = 1f;
	private float currentRange = 15f;
	private float damageChange = 5f;
	private float currentDamage = 50f;
	private float healthChange = 25f;
	private float currentHealth = 100f;



	// Use this for initialization
	void Start () {

		//Displays Upgrade Increments
		rangeUpgrade.text = "+1";
		firerateUpgrade.text = "+2";
		damageUpgrade.text = "+5";
		healthUpgrade.text = "+25";

		accessShop = GameObject.FindWithTag("GameShop").GetComponent<GameShop>();
		buildCost = accessShop.surfaceCost;
		upgradeCost = accessShop.costSurface;

		//Displays Costs
		buildText.text = "Build Cost: " + buildCost;
		upgradeText.text = "Upgrade Cost: " + upgradeCost;


	}

	public void AddUpgrades () {

		currentHealth += healthChange;
		currentRange += rangeChange;
		currentRate += rangeChange;
		currentDamage += damageChange;

	}
	
	// Update is called once per frame
	void Update () {

			//Displays Current Stats for Unit;
		firerateText.text = "Fire Rate: " + currentRate;
		rangeText.text = "Range: " + currentRange;
		damageText.text = "Damage: " + currentDamage;
		healthText.text = "Health: " + currentHealth;

	}
		
		
}
