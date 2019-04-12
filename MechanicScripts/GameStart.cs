using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	public GameObject playScreen;
	public GameObject controlScreen;

	void Start () {


	}

	public void OpenControls () {

		playScreen.SetActive (false);
		controlScreen.SetActive (true);

	}

	public void OpenHowtoPlay () {

		playScreen.SetActive (true);
		controlScreen.SetActive (false);

	}
}
