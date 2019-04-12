using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoInfo : MonoBehaviour {

	public Text currentTime;

	public Text upgradeText;

	private float waitTime = 30f;

	private float upgradeTime = 2.5f;

	public float clickCount;

	private float levelCount = 1f;

	public Text levelText;

	public GameObject upgradeButton;

	//private SoulHolder accessSoul;
	private float soulCount;


	// Use this for initialization
	void Start () {

		currentTime.text = "Production Time: " + waitTime.ToString() + "s";

		clickCount = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		//accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
		//soulCount = accessSoul.souls;

		if (clickCount == 5) {

			upgradeButton.SetActive (false);

			upgradeText.text = "Maxed";

			levelText.color = Color.green;

			Debug.Log ("Fully Upgraded");



		}	
	
		
	}

	public void ReduceTime () {

	waitTime -= upgradeTime;

	}

	
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
