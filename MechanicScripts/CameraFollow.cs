// Curtis Davis     January 5, 2018     Camera Following Script     Source: https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float turnSpeed = 0.40f;
    public Transform player;
    public float Ypos = 14f;
    public float Zpos = 15f;


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame after all items are processed from Update
	void LateUpdate ()
    {
        transform.position = new Vector3(player.position.x, player.position.y + Ypos, player.position.z + Zpos);

        transform.LookAt(player.position);

        transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * turnSpeed);
    }
}
