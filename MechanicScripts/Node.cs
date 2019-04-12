using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color blockedColor;

	private Renderer rend;
	private Color startColor;

	private GameObject unit;

	private SoulHolder accessSoul;
	private float soulCount;

	public GameObject placementSystem;

    public AudioSource audioSource;
    public AudioClip placementClip;
 
	void Start () {

		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;

        //audioSource = GetComponent<AudioSource>();
	}

	void Update () {

		accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
		soulCount = accessSoul.souls;

	}
	void OnMouseDown () {

        

        if (unit != null) {

			Debug.Log ("Can't Build Here!");

			return;

		}

        

        GameObject unitToBuild = GameShop.Instance.GetUnitToBuild();

		Debug.Log (unitToBuild);

		float priceToBuild = GameShop.Instance.GetPriceToBuild();

        if (soulCount >= priceToBuild){

        unit = (GameObject) Instantiate (unitToBuild, transform.position, transform.rotation);

		placementSystem.GetComponent<GameShop>().PurchaseMessage();

        GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (priceToBuild);

		Debug.Log ("Unit Built!"); 

		} else {

			placementSystem.GetComponent<GameShop>().InsufficientFundsMessage();

		}

	}

	void OnMouseEnter () {


		if (unit != null) {

			rend.material.color = Color.red;

			Debug.Log ("Can't Build Here!");

			return;
		} else {

			rend.material.color = hoverColor;
		}
	}

	void OnMouseExit () {

		rend.material.color = startColor;

	}

}
