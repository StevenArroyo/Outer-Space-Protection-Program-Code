using UnityEngine;
using UnityEngine.UI;


public class SoulHolder : MonoBehaviour {

 public static SoulHolder Instance { get; private set; }

 public float souls;

 private float startSouls = 0f;

 public AudioSource audioSource;
 public AudioClip placementClip;

    private void Awake () {

	 if (Instance == null) {

		 Instance = this;
		 DontDestroyOnLoad(gameObject);
	 }

	 else {

		 Destroy (gameObject);

	 }
 }


    	void Start () {
		
		souls = startSouls;

        audioSource = GetComponent<AudioSource>();

	}

		void Update () {

			if (Input.GetKeyDown (KeyCode.P)) {

				AddSouls (5000);

			}
		}


	public void AddSouls (float amount) {

		souls += amount;

		Debug.Log ("Souls Added!");

		return;

	}

	public void ReduceSouls (float amount) {

		souls -= amount;

		Debug.Log ("Souls Reduced");

        //audioSource.PlayOneShot(placementClip);

		return;

	}

	public void ResetSoulCount () {

		souls = startSouls;

	}


}


