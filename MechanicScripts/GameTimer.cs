﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public Text timerText;
	private float startTime;

	// Use this for initialization
	void Start () {

		startTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {

		float t = Time.time - startTime;

		string minutes = ((int) t / 60).ToString();
		string seconds = (t % 60).ToString("f2");

		timerText.text = "Survival Time" + "\n" + minutes + ":" + seconds;
		
	}
}
