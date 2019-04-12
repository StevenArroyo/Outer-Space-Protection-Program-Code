using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public GameObject StartButton;
    public GameObject Playgame;
    public GameObject HTP;
    public GameObject Credits;
    public GameObject Quit;



    // Use this for initialization
    void Start () {

        StartButton.SetActive(true);
        Playgame.SetActive(false);
        HTP.SetActive(false);
        Credits.SetActive(false);
        Quit.SetActive(false);

    }
	
	public void OpenGame()
    {

        StartButton.SetActive(false);
        Playgame.SetActive(true);
        HTP.SetActive(true);
        Credits.SetActive(true);
        Quit.SetActive(true);


    }


}
