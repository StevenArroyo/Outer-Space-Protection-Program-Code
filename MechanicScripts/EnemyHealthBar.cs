using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	public Image enemyHealthBar;
	private GameObject target;
	public GameObject Healthbar;

	//private Vector3 targetPoint;
	//private Quaternion targetRotation;


	// Use this for initialization
	void Start () {

		enemyHealthBar.fillAmount = 1;

		target = GameObject.FindGameObjectWithTag ("Player");

	}
	// Update is called once per frame
	void Update () {

		//targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
       // targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

		if (enemyHealthBar.fillAmount <= 0.4f) {

				GetComponent<Image>().color = Color.red;
		} else {

				GetComponent<Image>().color = Color.green;

		}
		
	}


}
