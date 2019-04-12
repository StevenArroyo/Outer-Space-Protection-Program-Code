using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar_Rotation : MonoBehaviour {

	private Transform target;
	private float damp = 5f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		target = GameObject.FindWithTag ("Player").transform;

		var rotationAngle = Quaternion.LookRotation ( target.position - transform.position);
         transform.rotation = Quaternion.Slerp ( transform.rotation, rotationAngle, Time.deltaTime * damp);


	}
}
