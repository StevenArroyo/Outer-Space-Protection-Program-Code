using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour {

	public Text upgradecostText;

	[SerializeField]
	private float cost;

	public Text upgradeName;
	public Text upgradeInfo;
	public RawImage upgradeImage;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {


	}


	public void UpgradeInfo() {

		upgradecostText.text = ("Cost: ") + cost.ToString ("0");
		upgradeName.text = ("Shotgun");
		upgradeInfo.text = ("This upgrade will increase this weapon's stats all around." + "\n" + "\n" + 
			"Range: +1" + "\n" +
			"Damage: +10" + "\n" +
			"Fire Rate: +5");


	}
}
