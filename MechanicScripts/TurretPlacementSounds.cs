using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacementSounds : MonoBehaviour {

    AudioSource audioSource;
    AudioClip turretPlacementClip;
    GameObject[] Nodes;
	// Use this for initialization
	void Start ()
    {
        Nodes = GameObject.FindGameObjectsWithTag("Nodes");
        audioSource = GetComponent<AudioSource>();
	}

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(turretPlacementClip);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        OnMouseOver(); 
	}
}
