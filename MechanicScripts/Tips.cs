using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour {

    private bool isLearnt;
    private bool tasTurretEnabled = true;
    private bool tasAmmoEnabled = true;
    private string tasTurret = "You can go to the shop [Press Tab] and Buy or Upgrade a turret! Make   sure to spend wisely! \n  [Press Enter to Exit]";
    private string tasAmmo = "Grab some Ammo in the shop! [Press Tab]";
    private SoulHolder accessSoul;
    private PlayerShooting ammoCount;
    private float soulCount;
    private float backupAmmo;
    

	// Use this for initialization
	void Start ()
    {
        tasTurretEnabled = false;
        tasAmmoEnabled = false;
	}

    private void OnGUI()
    {
        if (tasTurretEnabled)
        {
            tasTurret = GUI.TextArea(new Rect(600, 375, 150, 100), tasTurret, 250);
            tasAmmo = GUI.TextArea(new Rect(600, 375, 150, 100), tasAmmo, 250);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
        soulCount = accessSoul.souls;
        backupAmmo = ammoCount.backupAmmo;

        if (soulCount >= 1000 && !isLearnt)
        {
            tasTurretEnabled = true;
        }

        if(soulCount >=500 && backupAmmo <= 0 && !isLearnt)
        {
            tasAmmoEnabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isLearnt = true;
            tasTurretEnabled = false;
            tasAmmoEnabled = false;
        }   
    }
}
