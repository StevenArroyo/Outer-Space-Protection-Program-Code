using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Transform PCanvas;

    public GameObject shotgun;

    public GameObject SORcanvas;

	void Start () {


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
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (PCanvas.gameObject.activeInHierarchy == false)
        {
            PCanvas.gameObject.SetActive(true);

            
           
            SORcanvas.SetActive (false);

            Time.timeScale = 0;

			Cursor.visible = true;
        }
       else
       {
           PCanvas.gameObject.SetActive(false);
           
           SORcanvas.SetActive (true);

            

            Time.timeScale = 1;

		Cursor.visible = false;
       }


        


    }


    public void resume()
    {

        if(PCanvas.gameObject.activeInHierarchy == true)
        {
            PCanvas.gameObject.SetActive(false);

          


            Time.timeScale = 1;

        }




    }
}
