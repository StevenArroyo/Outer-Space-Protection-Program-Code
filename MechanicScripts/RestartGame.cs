using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    private SoulHolder accessSouls;

    public static RestartGame instance = null;

    public void RestartTheGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     
        SoulHolder soul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();

        soul.ResetSoulCount();

        Debug.Log ("Souls Reset");
    }
}
