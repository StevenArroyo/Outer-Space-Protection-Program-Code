using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthBar : MonoBehaviour {

	public Image baseHealthBar;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (baseHealthBar.fillAmount <= 0.4f) {

				GetComponent<Image>().color = Color.red;
		}
		else {

				GetComponent<Image>().color = Color.green;
		}
		
	}
}
