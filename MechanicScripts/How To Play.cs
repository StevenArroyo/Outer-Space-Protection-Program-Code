using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

	public GameObject playScreen;
	public GameObject controlScreen;

	public void OpenControls () {

		playScreen.SetActive (false);
		controlScreen.SetActive (true);

	}

	public void OpenHowtoPlay () {

		playScreen.SetActive (true);
		controlScreen.SetActive (false);

	}
}
