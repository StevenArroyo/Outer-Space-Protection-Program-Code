using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

	private float startHealth = 2000f;
	public float currentHealth;

	public Image healthBar;
	public GameObject gameOver;

	[Header ("Game Over Refs")]

	public GameObject playerHUD;
	public GameObject SORcanvas;
	public GameObject pauseController;
	public GameObject player;
	public GameObject crosshair;

	public GameObject winPopup;

	public Text healthAmount;
    string SoulDropString = "SoulDropPickup";

	// Use this for initialization
	void Start () {
		
		currentHealth = startHealth;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {

	if (Time.timeScale == 0) {

			Cursor.visible = true;

			Cursor.lockState = CursorLockMode.None;

		} else if (Time.timeScale > 0) {

			Cursor.visible = false;

			Cursor.lockState = CursorLockMode.Locked;
		}

		healthBar.fillAmount = currentHealth / startHealth;

		if (currentHealth <= 0) {

			GameOver();

		}

	healthAmount.text = currentHealth.ToString ("F0");
		
	}

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Boss") && (currentHealth > 0))
        {
            
            currentHealth -= 500;

			GameObject.FindWithTag("Spawner").GetComponent<EnemyWaveSpawner_SS>().DecreaseCount(1);
			


        }


    }

      

	public void GameOver () {

		gameOver.SetActive (true);

		Time.timeScale = 0;

		playerHUD.SetActive (false);
		pauseController.SetActive (false);
		SORcanvas.SetActive (false);
		crosshair.SetActive (false);



	}

	public void TriggerWin () {

	Invoke ("WinScreen", 10f);

	}
	public void WinScreen () {

		winPopup.SetActive (true);
		playerHUD.SetActive (false);
		crosshair.SetActive (false);
		pauseController.SetActive (false);
		SORcanvas.SetActive (false);

		Time.timeScale = 0;



	}

	public void TakeDamage () {

		currentHealth -= (30f * Time.deltaTime);

		healthBar.fillAmount = currentHealth / startHealth;

		Debug.Log ("Base Taking Damage Over Time");

	}

	public void UpgradeHealth (float amount) {

		currentHealth += amount;

		startHealth += amount;

		healthAmount.text = currentHealth.ToString ("F0");

		healthBar.fillAmount = currentHealth / startHealth;

	}

}
