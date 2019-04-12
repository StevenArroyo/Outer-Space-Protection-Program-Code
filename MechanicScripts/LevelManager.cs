using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject fpsChecker;

    public Text soulText;
    public Text soulShopText;

    void Update (){

        if (Input.GetKeyDown (KeyCode.I)) {

            fpsChecker.SetActive (true);
        }

        soulShopText.text = "Energy Souls: " + SoulHolder.Instance.souls.ToString();
        soulText.text = "Energy Souls: " + SoulHolder.Instance.souls.ToString();


    }

    public void ClickChangeScene(int ChangeScene)
    {
        SceneManager.LoadScene(ChangeScene);

        
    }

    public void ResetSoulCount () {

    SoulHolder soul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();

        soul.ResetSoulCount();

        Debug.Log ("Souls Reset");

    }

    //private void Start () {

        //soulShopText.text = SoulHolder.Instance.souls.ToString();
        //soulText.text = SoulHolder.Instance.souls.ToString();

    //}

}
