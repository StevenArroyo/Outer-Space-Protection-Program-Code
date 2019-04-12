using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera_SS : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    PlayerController charController;
    float rotateVel = 0;






	void Start ()
    {
        SetCameraTarget(target);
    }
	
    //this method can be used to change the cameras target to focus on anything- this can be useful!
	public void SetCameraTarget (Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<PlayerController>())
            {
                charController = target.GetComponent<PlayerController>();
            }
            else
                Debug.LogError("Camera's target needs a Character Controller.");
        }
        else
            Debug.LogError("!!!Camera needs a target.");
    }



	void LateUpdate () {
        //moving
        MoveToTarget();

        //rotating
        LookAtTarget();
	}

    void MoveToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void LookAtTarget ()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);

    }


}
