using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SORCanvas : MonoBehaviour {

    public Transform PCanvas;

	public GameObject player;

	public GameObject crosshairCanvas;

    public GameObject pauseMenu;

    public GameObject shotgun;

    public GameObject playerView;

    public GameObject playerHUD;
    public GameObject placementView;
    public GameObject placementNodes;

    public GameObject playerUScreen;
    public GameObject wepUScreen;


	void Start () {

       // OpenHowtoPlay ();


	}

    // Update is called once per frame
    void Update()
    {
		if (Time.timeScale == 0) {

			Cursor.visible = true;

			Cursor.lockState = CursorLockMode.None;

		} else {

			Cursor.visible = false;

			Cursor.lockState = CursorLockMode.Locked;
		}			

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (PCanvas.gameObject.activeInHierarchy == false)
        {
			crosshairCanvas.SetActive (false);
            PCanvas.gameObject.SetActive(true);
            shotgun.SetActive (false);
            pauseMenu.SetActive (false);
            playerView.SetActive (false);
            placementNodes.SetActive (true);
            playerHUD.SetActive (false);
            placementView.SetActive (true);

            Time.timeScale = 0;

			player.SetActive (false);

        }
        else
        {
			crosshairCanvas.SetActive (true);
            PCanvas.gameObject.SetActive(false);
            shotgun.SetActive (true);
            pauseMenu.SetActive (true);
            playerView.SetActive (true);
            placementNodes.SetActive (false);
            playerHUD.SetActive (true);
            placementView.SetActive (false);

            Time.timeScale = 1;

			player.SetActive (true);
        }

        	if (playerUScreen.activeSelf) {

		    playerUScreen.SetActive (false);

            }

            if (wepUScreen.activeSelf) {

            wepUScreen.SetActive (false);

            }
    }
}
