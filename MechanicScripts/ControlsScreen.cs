using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScreen : MonoBehaviour {

	public GameObject controlsScreen;
	public GameObject creditsScreen;
    public GameObject shotgun;
	public GameObject planet;



	public void OpenControls () {

		controlsScreen.SetActive (true);
		//planet.SetActive (false);
	}

	public void CloseControls () {

		controlsScreen.SetActive (false);
		//planet.SetActive (true);

	}

	public void OpenCredits () {

		creditsScreen.SetActive (true);
		//planet.SetActive (false);
     

	}

	public void CloseCredits () {

		creditsScreen.SetActive (false);
		//planet.SetActive (true);

	}




}
