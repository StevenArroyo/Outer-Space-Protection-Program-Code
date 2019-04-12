using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Gas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartButton () {

		SceneManager.LoadScene ("Atmos");

		SoulHolder soul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();

        soul.ResetSoulCount();

        Debug.Log ("Souls Reset");

	}

	public void MainMenuButton () {

		SceneManager.LoadScene ("Start Menu");

		SoulHolder soul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();

        soul.ResetSoulCount();

        Debug.Log ("Souls Reset");

	}

	public void QuitButton () {

		Application.Quit ();

	}
}
