using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

	public GameObject levelSelector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenLevelSelector () {

	levelSelector.SetActive (true);

	}

	public void CloseLevelSelector (){

	levelSelector.SetActive (false);

	}
}
