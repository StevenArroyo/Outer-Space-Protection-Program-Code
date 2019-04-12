using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {


	public Text upgradecostText;

	[SerializeField]
	private float cost;

	public Text upgradeName;
	public Text upgradeInfo;
	public RawImage upgradeImage;

	// Use this for initialization
	void Start () {

		UpgradeInfo ();

	}

	// Update is called once per frame
	void Update () {


	}
		

	public void UpgradeInfo() {

		upgradecostText.text = ("Cost: ") + cost.ToString ("0");
		upgradeName.text = ("Health");
		upgradeInfo.text = ("This upgrade will increase the player's current health stat." + "\n" + "\n" + "Health: +25");


	}
}
