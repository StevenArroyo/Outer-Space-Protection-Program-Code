using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PController_SA : MonoBehaviour {

    public float currentSpeed = 5.0f;
    public float MovementSpeed = 5.0f;
    public float lookSensitivity = 3.0f;
    private GameObject AmmoDropPickup;
    public float runSpeed = 10.0f;
    private bool isRunning;

    public AudioSource audioSource;
    public AudioClip moving;
    public AudioClip soulPickup;
    public AudioClip ammoPickup;
    CharacterController cc;

    private CameraMotor motor;

	// Use this for initialization
	void Start () {

        currentSpeed = MovementSpeed;
        motor = GetComponent<CameraMotor>();

        audioSource = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * MovementSpeed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        motor.RotateCamera(_cameraRotation);

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;

            MovementSpeed = runSpeed;

        }
        else
        {
            isRunning = false;
            MovementSpeed = currentSpeed;
        }

        if (MovementSpeed >= 5f)
        {
            StartCoroutine(PlaySounds());
        }

    }

    IEnumerator PlaySounds()
    {

        if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f)
        {
            audioSource.clip = moving;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (audioSource.isPlaying)
            {
                yield return new WaitForSeconds(10000000);
                audioSource.Stop();
            }
        }


    }





    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "SoulDrop")
        {
            GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().AddSouls(250);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(soulPickup, 1f);
        }

        if (other.tag == "BossSoulDrop")
        {

            GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().AddSouls(500);
            Destroy(other.gameObject);
        }

        if (other.tag == "AmmoDrop")
        {

            GameObject.FindWithTag("AmmoHolder").GetComponent<PlayerShooting>().AddAmmo();
            Destroy(other.gameObject);
            audioSource.PlayOneShot(ammoPickup);
        }

    }

    public void UpgradeSpeed (float amount) {

    currentSpeed += amount;
        
    MovementSpeed += amount;   

    }    
    		
}
