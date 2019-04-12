using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameShop : MonoBehaviour {

	 public static GameShop Instance { get; private set; }

	[Header ("Machine Turret Upgrades")]
	public GameObject machineTurret;
	public GameObject machineBullet;
	public float machineRange;
	public float machineRate;
	public float machineDamage;
	public float machineHealth;

	[Header ("Laser Turret Upgrades")]
	public GameObject laserTurret;
	public float laserRange;
	public float laserDamage;
	public float laserHealth;

	[Header ("Ammo Machine Upgrades")]
	public GameObject ammoMachine;

	public float waitTime = 2.5f;

	[Header ("Surface to Air Upgrades")]
	public GameObject surfaceUnit;
	public GameObject surfaceMissile;
	public float surfaceRange;
	public float surfaceRate;
	public float surfaceDamage;
	public float surfaceHealth;

	[Header ("Mech Suit Upgrades")]
	public GameObject mechSuit;

	[Header ("Player Upgrades")]
	public GameObject player;
	public float playerhealthUpgrade = 1000f;
	public float playerspeedUpgrade = 1f;
	public GameObject shotgunBullet;
	public float shotgunDamage = 25f;
	public float shotgunRange = 0.2f;
	public GameObject enemy;

	public float ammoIncrease = 5f;


	[Header ("Build Cost")]

	public float machineCost = 1000;
	public float laserCost = 2000;
	public float ammoCost = 1000;
	public float mechCost = 2500;
	public float surfaceCost = 1000;

	public Text soulText;


	[Header ("Upgrade Cost")]
		
	public float costHealth = 1000;
	public float costMachine = 1000;
	public float costLaser = 1000;
	public float costAmmo = 1000;
	public float costSpeed = 1000;
	public float costShotgun = 1500;
	public float costMech = 1500;
	public float costSurface = 1000;

	private float costPlayerUpgrades = 1000f;

	[Header ("Upgrade Buttons")]
	public GameObject healthUpgrade;
	public GameObject machineUpgrade;
	public GameObject laserUpgrade;
	public GameObject rocketUpgrade;
	public GameObject speedUpgrade;
	public GameObject shotgunUpgrade;
	public GameObject mechUpgrade;
	public GameObject surfaceUpgrade;
	public GameObject ammoUpgradeButon;

	[Header ("Placement Mode")]
	private GameObject unitToBuild;

	private float priceToBuild;
	public GameObject machineturretPrefab;
	public GameObject laserturretPrefab;
	public GameObject ammomachinePrefab;
	public GameObject surfacetoairPrefab;

	public GameObject bulletPrefab;


	public GameObject nodes;
	public GameObject canvasMode;

	public GameObject placementView;
	public GameObject playerView;
	public GameObject placementScreen;
	public GameObject crosshairCanvas;
	public GameObject playerHUD;
	public GameObject shotgun;
	public GameObject pauseMenu;

	public GameObject wepUpgrades;
	public GameObject playerUpgrades;

	public static GameShop instance;

	private SoulHolder accessSoul;
	private float soulCount;

	[Header ("Upgrade System")]

	//Machine Turret Prefabs
	public GameObject lvl1Machine;
	public GameObject lvl2Machine;
	public GameObject lvl3Machine;
	public GameObject lvl4Machine;
	public GameObject lvl5Machine;

	//Laser Turret Prefabs
	public GameObject lvl1Laser;
	public GameObject lvl2Laser;
	public GameObject lvl3Laser;
	public GameObject lvl4Laser;
	public GameObject lvl5Laser;

	//Surface to Air Prefabs
	public GameObject lvl1Surface;
	public GameObject lvl2Surface;
	public GameObject lvl3Surface;
	public GameObject lvl4Surface;
	public GameObject lvl5Surface;

	//Ammo Machine Prefabs

	public GameObject lvl1Ammo;
	public GameObject lvl2Ammo;
	public GameObject lvl3Ammo;
	public GameObject lvl4Ammo;
	public GameObject lvl5Ammo;


	private float machinecounter = 0;
	public Text machineTxt;
	private float lasercounter = 0;
	public  Text laserTxt;
	private float surfacecounter = 0;
	public Text surfaceTxt;
	private float ammocounter = 0;
	public Text ammoTxt;
	private float BHcounter = 0;
	public Text BHTxt;
	private float ALcounter = 0;
	public Text ALTxt;
	private float Scounter = 0;
	public Text speedTxt;
	private float Prangecounter = 0;
	public Text prangeTxt;
	private float Pdamagecounter = 0;
	public Text pdamageTxt;

	

	public AudioSource audioSource;
    public AudioClip placementClip;
	public AudioClip upgradeClip;
	public AudioClip failbuyClip;

	public Transform shopCanvas;
	public GameObject purchasetxtPrefab;

	public GameObject insufficienttxtPrefab;

	public GameObject upgradetxtPrefab;

	public GameObject damageButton;
	public GameObject rangeButton;
	public GameObject speedButton;
	public GameObject baseHealthButton;
	public GameObject ammoLimitButton;


 private void Awake () {

	 if (Instance == null) {

		 Instance = this;
	 }

	 else {

		 Destroy (gameObject);

	 }
 }

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();


	}

	public GameObject GetUnitToBuild () {


		return unitToBuild;

	}

	public float GetPriceToBuild () {

		return priceToBuild;

	}
	
	// Update is called once per frame
	void Update () {

		accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
		soulCount = accessSoul.souls;


		

	}

	public void BuildMachineTurret () {


		if (soulCount >= machineCost) {

				Debug.Log ("Souls reduced!");

				if (machinecounter == 0) {

					machineturretPrefab = lvl1Machine;

				}

			unitToBuild = machineturretPrefab;

			priceToBuild = machineCost;

			} else {

				InsufficientFundsMessage ();

				Debug.Log ("Not enough Souls!");

			}

		}

	public void BuildLaserTurret () {

		if (soulCount >= laserCost) {

			Debug.Log ("Souls reduced!");

			if (lasercounter == 0) {

				laserturretPrefab = lvl1Laser;

			}

			unitToBuild = laserturretPrefab;

			priceToBuild = laserCost;

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}
	}


	public void BuildAmmoMachine () {

		if (soulCount >= ammoCost) {

			Debug.Log ("Souls reduced!");

			if (ammocounter == 0) {

				ammomachinePrefab = lvl1Ammo;

			}

			unitToBuild = ammomachinePrefab;

			priceToBuild = ammoCost;


		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}
	}

	public void BuildSurfacetoAir () {

		if (soulCount >= surfaceCost) {

			Debug.Log ("Souls reduced!");

			if (surfacecounter == 0) {

				surfacetoairPrefab = lvl1Surface;

				Debug.Log ("surface to air is set to level 1!!!");

			}

			unitToBuild = surfacetoairPrefab;

			priceToBuild = surfaceCost;

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}
	}

	public void UpgradeMachine () {

		if (soulCount >= costMachine) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costMachine);

			Debug.Log ("Souls reduced!");

			UpgradeMessage ();

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}

		if (machinecounter == 1) {

			machineTxt.text = "Lvl. 2";

			machineturretPrefab = lvl2Machine;

			unitToBuild = machineturretPrefab;

			Debug.Log ("Machine Turret Lvl 2");

		}

		if (machinecounter == 2) {

			machineTxt.text = "Lvl. 3";

			machineturretPrefab = lvl3Machine;

			unitToBuild = machineturretPrefab;

			Debug.Log ("Machine Turret Lvl 3");

		}

		if (machinecounter == 3) {

			machineTxt.text = "Lvl. 4";

			machineturretPrefab = lvl4Machine;

			unitToBuild = machineturretPrefab;

			Debug.Log ("Machine Turret Lvl 4");

		}

		if (machinecounter == 4) {

			machineTxt.text = "Lvl. 5";

			machineturretPrefab = lvl5Machine;

			unitToBuild = machineturretPrefab;

			machineUpgrade.SetActive (false);

			Debug.Log ("Machine Turret Lvl 5");

		}

		Debug.Log (machineturretPrefab);
		
	}

	public void UpgradeLaser () {

		if (soulCount >= costLaser) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costLaser);

			Debug.Log ("Souls reduced!");

			UpgradeMessage ();

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}

		if (lasercounter == 1) {

			laserTxt.text = "Lvl. 2";

			laserturretPrefab = lvl2Laser;

			unitToBuild = laserturretPrefab;

			Debug.Log ("Laser Turret Lvl 2");

		}

		if (lasercounter == 2) {

			laserTxt.text = "Lvl. 3";

			laserturretPrefab = lvl3Laser;

			unitToBuild = laserturretPrefab;

			Debug.Log ("Laser Turret Lvl 3");

		}

		if (lasercounter == 3) {

			laserTxt.text = "Lvl. 4";

			laserturretPrefab = lvl4Laser;

			unitToBuild = laserturretPrefab;

			Debug.Log ("Laser Turret Lvl 4");

		}

		if (lasercounter == 4) {

			laserTxt.text = "Lvl. 5";

			laserturretPrefab = lvl5Laser;

			unitToBuild = laserturretPrefab;

			laserUpgrade.SetActive (false);

			Debug.Log ("Laser Turret Lvl 5");

		}

		Debug.Log (laserturretPrefab);
	}

	public void UpgradeAmmoMachine () {

		if (soulCount >= costAmmo) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costAmmo);

			GetUnitToBuild ();

			UpgradeMessage ();

			Debug.Log ("Souls reduced!");

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}

		if (ammocounter == 1) {

			ammoTxt.text = "Lvl. 2";

			ammomachinePrefab = lvl2Ammo;

			unitToBuild = ammomachinePrefab;

			Debug.Log ("Ammo Machine Lvl 2");

		}

		if (ammocounter == 2) {

			ammoTxt.text = "Lvl. 3";

			ammomachinePrefab = lvl3Ammo;

			unitToBuild = ammomachinePrefab;

			Debug.Log ("Ammo Machine Lvl 3");

		}

		if (ammocounter == 3) {

			ammoTxt.text = "Lvl. 4";

			ammomachinePrefab = lvl4Ammo;

			unitToBuild = ammomachinePrefab;

			Debug.Log ("Ammo Machine Lvl 4");

		}

		if (ammocounter == 4) {

			ammoTxt.text = "Lvl. 5";

			ammomachinePrefab = lvl5Ammo;

			unitToBuild = ammomachinePrefab;

			Debug.Log ("Ammo Machine Lvl 5");

			ammoUpgradeButon.SetActive (false);

		}
	}

		public void UpgradeSurfacetoAir () {

		if (soulCount >= costSurface) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costSurface);

			GetUnitToBuild ();

			UpgradeMessage ();

			Debug.Log ("Souls reduced!");


		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}

		if (surfacecounter == 1) {

			surfaceTxt.text = "Lvl. 2";

			surfacetoairPrefab = lvl2Surface;

			unitToBuild = surfacetoairPrefab;

		}

		if (surfacecounter == 2) {

			surfaceTxt.text = "Lvl. 3";

			surfacetoairPrefab = lvl3Surface;

			unitToBuild = surfacetoairPrefab;

		}

		if (surfacecounter == 3) {

			surfaceTxt.text = "Lvl. 4";

			surfacetoairPrefab = lvl4Surface;

			unitToBuild = surfacetoairPrefab;

		}

		if (surfacecounter == 4) {

			surfaceTxt.text = "Lvl. 5";

			surfacetoairPrefab = lvl5Surface;

			unitToBuild = surfacetoairPrefab;

			surfaceUpgrade.SetActive (false);

		}

		Debug.Log (surfacetoairPrefab);
	}

	public void UpgradeSpeed () {

		if (soulCount >= costPlayerUpgrades) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costPlayerUpgrades);

			player.GetComponent<PController_SA> ().UpgradeSpeed (playerspeedUpgrade);

			Debug.Log ("Souls reduced!");

				if (Scounter == 1) {

				speedTxt.text = "Lvl. 2";

			}	if (Scounter == 2) {

				speedTxt.text = "Lvl. 3";

			}	if (Scounter == 3) {

				speedTxt.text = "Lvl. 4";

			}	if (Scounter == 4) {

				speedTxt.text = "Lvl. 5";

			}
				if (Scounter == 5) {

				speedTxt.text = "Lvl. 6";

				speedButton.SetActive (false);

			}

			UpgradeMessage ();

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}
	}

	public void UpgradeShotgunRange () {

		if (soulCount >= costPlayerUpgrades) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costPlayerUpgrades);

			bulletPrefab.GetComponent<Bullet> ().UpgradeRange (shotgunRange);

			Debug.Log ("Souls reduced!");

			if (Prangecounter == 1) {

				prangeTxt.text = "Lvl. 2";

			}	
			if (Prangecounter == 2) {

				prangeTxt.text = "Lvl. 3";

			}	
			if (Prangecounter == 3) {

				prangeTxt.text = "Lvl. 4";

			}	
			if (Prangecounter == 4) {

				prangeTxt.text = "Lvl. 5";

			}
			if (Prangecounter == 5) {

				prangeTxt.text = "Lvl. 6";
				rangeButton.SetActive (false);

			}

			UpgradeMessage ();

		} else { 

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}
	}

	public void UpgradeAmmoLimit () {

		if (soulCount >= costPlayerUpgrades) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costPlayerUpgrades);

			shotgun.GetComponent<PlayerShooting>().UpgradeAmmoLimit (ammoIncrease);

			Debug.Log ("Souls reduced!");

			if (ALcounter == 1) {

				ALTxt.text = "Lvl. 2";

			}
			if (ALcounter == 2) {

				ALTxt.text = "Lvl. 3";

			}	
			if (ALcounter == 3) {

				ALTxt.text = "Lvl. 4";

			}	
			if (ALcounter == 4) {

				ALTxt.text = "Lvl. 5";

			}	
			if (ALcounter == 5) {

				ALTxt.text = "Lvl. 6";
				ammoLimitButton.SetActive (false);

			}

			UpgradeMessage ();

		} else {

			InsufficientFundsMessage ();

			Debug.Log ("Not enough Souls!");

		}

		}

	public void UpgradeBaseHealth () {


		if (soulCount >= costPlayerUpgrades) {

		GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costPlayerUpgrades);

		GameObject.FindWithTag("Base").GetComponent<BaseHealth>().UpgradeHealth (250);

			if (BHcounter == 1) {

				BHTxt.text = "Lvl. 2";

			}	
			if (BHcounter == 2) {

				BHTxt.text = "Lvl. 3";

			}	
			if (BHcounter == 3) {

				BHTxt.text = "Lvl. 4";

			}	
			if (BHcounter == 4) {

				BHTxt.text = "Lvl. 5";

			}	
			if (BHcounter == 5) {

				BHTxt.text = "Lvl. 6";
				baseHealthButton.SetActive (false);

			}

		UpgradeMessage ();

		Debug.Log ("Souls reduced!");

		} else {
		
		InsufficientFundsMessage ();

		Debug.Log ("Not enough Souls!");

		}


	}



	public void UpgradeShotgunDamage () {

		if (soulCount >= costPlayerUpgrades) {

			GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (costPlayerUpgrades);

			enemy.GetComponent<EnemyHealth> ().UpgradeShotgunDamage (shotgunDamage);

			if (Pdamagecounter == 1) {

				pdamageTxt.text = "Lvl. 2";

			}
			if (Pdamagecounter == 2) {

				pdamageTxt.text = "Lvl. 3";

			}
			if (Pdamagecounter == 3) {

				pdamageTxt.text = "Lvl. 4";

			}
			if (Pdamagecounter == 4) {

				pdamageTxt.text = "Lvl. 5";

			}
			if (Pdamagecounter == 5) {

				pdamageTxt.text = "Lvl. 6";
				damageButton.SetActive (false);

			}

			UpgradeMessage ();

		Debug.Log ("Souls reduced!");

		} else {

		InsufficientFundsMessage ();

		Debug.Log ("Not enough Souls!");

		}
		
	}

	public void BeginWave () {

		crosshairCanvas.SetActive (true);
		player.SetActive (true);
		shotgun.SetActive (true);
		pauseMenu.SetActive (true);
		playerHUD.SetActive (true);
		placementScreen.SetActive (false);
		placementView.SetActive (false);
		nodes.SetActive (false);
		playerView.SetActive (true);
        
        Time.timeScale = 1;
    }

	public void OpenWepUpgrades () {

		if (nodes.activeSelf) {

		nodes.SetActive (false);

		}

		wepUpgrades.SetActive (true);
		playerUpgrades.SetActive (false);


	}

	public void CloseWepUpgrades () {

		if (!nodes.activeSelf) {

		nodes.SetActive (true);

		}

		wepUpgrades.SetActive (false);


	}

	public void OpenPlayerUpgrades () {

		if (nodes.activeSelf) {

		nodes.SetActive (false);

		}

		playerUpgrades.SetActive (true);
		wepUpgrades.SetActive (false);

	}

	public void ClosePlayerUpgrades () {

		if (!nodes.activeSelf) {

		nodes.SetActive (true);

		}

		playerUpgrades.SetActive (false);

	}

	public void MachineUpgradeLimit () {

		if (soulCount >= costMachine) {

		machinecounter++;

		}
	
	}

	public void LaserUpgradeLimit () {

		if (soulCount >= costLaser) {

		lasercounter++;
		}

	}

	public void SurfaceUpgradeLimit () {

		if (soulCount >= costSurface) {

		surfacecounter++;
		}

	}

	public void AmmoUpgradeLimit () {

		if (soulCount >= costAmmo) {

		ammocounter++;

		}

	}

	public void BaseHealthLimit () {

		if (soulCount >= costPlayerUpgrades) {

		BHcounter++;

		}


	}

	public void AmmoLimitLimit () {

	if (soulCount >= costPlayerUpgrades) {

		ALcounter++;

		}


	}

	public void SpeedLimit () {

			if (soulCount >= costPlayerUpgrades) {

		Scounter++;

		}


	}

	public void RangeLimit () {

			if (soulCount >= costPlayerUpgrades) {

		Prangecounter++;

		}



	}

	public void DamageLimit () {

			if (soulCount >= costPlayerUpgrades) {

		Pdamagecounter++;

		}



	}

	public void PurchaseMessage () {

 	GameObject purchaseTxt = (GameObject) Instantiate (purchasetxtPrefab, transform.position, transform.rotation);
	purchaseTxt.transform.SetParent (shopCanvas, false);

	audioSource.PlayOneShot(placementClip);


	}

	public void UpgradeMessage () {

	GameObject upgradeTxt = (GameObject) Instantiate (upgradetxtPrefab, transform.position, transform.rotation);
	upgradeTxt.transform.SetParent (shopCanvas, false);

	audioSource.PlayOneShot(upgradeClip);


	}

	public void InsufficientFundsMessage () {

	GameObject insufficientTxt = (GameObject) Instantiate (insufficienttxtPrefab, transform.position, transform.rotation);
	insufficientTxt.transform.SetParent (shopCanvas, false);

	audioSource.PlayOneShot(failbuyClip);
	
	}

}
