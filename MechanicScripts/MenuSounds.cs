// Source: https://www.youtube.com/watch?v=FxedJgTsFyQ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuSounds : MonoBehaviour
{
    public AudioClip buttonSound;
    private Button Buttons { get { return GetComponent<Button>(); } }
    private AudioSource Sources { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start()
    {

        Time.timeScale = 1;
        gameObject.GetComponent<AudioSource>();
        Sources.clip = buttonSound;
        Sources.playOnAwake = false;

        Buttons.onClick.AddListener(() => PlaySound());
    }

    // Update is called once per frame
    void PlaySound()
    {
        Sources.PlayOneShot(buttonSound, 10f);
    }
}
