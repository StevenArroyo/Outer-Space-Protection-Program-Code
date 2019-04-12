using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechSuit : MonoBehaviour {

	public Text costText;
	public Text upgradecostText;

	[SerializeField]
	private float cost;



	public Text unitText;
	public Text infoText;
	public RawImage unitImage;

	public Text upgradeName;
	public Text upgradeInfo;
	public RawImage upgradeImage;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}



	public void BuildInfo() {

		costText.text = ("Cost: ") + cost.ToString ("0");
		unitText.text = ("Mech Suit");
		infoText.text = ("This suit gives the player extra protection, as well as a speed and damage boost" + "\n" + "\n" + 
			"Movement Speed: 5" + "\n" +
			"Damage: 10" + "\n" +
			"Health: 100");



	}

	public void UpgradeInfo() {

		upgradecostText.text = ("Cost: ") + cost.ToString ("0");
		upgradeName.text = ("Mech Suit");
		upgradeInfo.text = ("This upgrade will increase this unit's stats all around." + "\n" + "\n" + 
			"Movement Speed: +1" + "\n" +
			"Damage: +5" + "\n" +
			"Health: +10");


	}
}
