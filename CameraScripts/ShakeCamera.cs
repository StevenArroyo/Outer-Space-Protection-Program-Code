// Scott Schubr January 7th 2017
// Credits to Unity Pro Tutorials, Renaissance Coders, Brackeys, and Sharp Accent tutorials, as well as other Youtube tutorials.

using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {

    public float positionShakeSpeed = 0.1f;
    public Vector3 positionShakeRange = new Vector3(0.1f, 0.1f, 0.1f);

	private Vector3 position;

	void Start () 
    {
        position = transform.localPosition;
	}
	
	void Update () 
    {
        if (positionShakeSpeed > 0)
        {
            transform.localPosition = position + Vector3.Scale(SmoothRandom.GetVector3(positionShakeSpeed), positionShakeRange);
        }
	}
}
