using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    //public GameObject player;

    public Text currAmmo;
    public GameObject reloadText;
    public GameObject shotgun;

    public int bulletCount;
    public float spreadAngle;
    public float bulletfirevelocity = 10.0f;
    public GameObject Bullet;
	public GameObject shotgunEffect;
    public Transform BulletExit;
    List<Quaternion> bullets;
    public GameObject AmmoButton;
    public GameObject player;

    float timer;
    public float fireRate;
    public float backupAmmo;

    private float startBackupAmmo = 25f;
    private float currentAmmo;
    public float FullAmmo = 5;
    public float reloadTime = 2f;
    private bool isReloading;
    private bool isShooting;
    private GUIStyle guiStyle = new GUIStyle();
    public Font myFont;

    public Animator anim;

    private SoulHolder accessSoul;
    private float soulCount;

    private Animator reloadAnim;

    private AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip reloading;

    // Use this for initialization
    void Start () {

        backupAmmo = startBackupAmmo;

        currentAmmo = 5;

        bullets = new List<Quaternion>(new Quaternion[bulletCount]);

        for (int i = 0; i < bulletCount; i++)
        {
            bullets.Add(Quaternion.Euler(Vector3.zero));

        }

        reloadAnim = GetComponent<Animator>();

        audioSource = player.GetComponent<AudioSource>();

	}




    // Update is called once per frame
    void Update() {


        if ((currentAmmo == 0) && (backupAmmo == 0)) {

            reloadAnim.enabled = !reloadAnim.enabled;

        }

        accessSoul = GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>();
        soulCount = accessSoul.souls;
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L)) {

            Destroy(GameObject.FindWithTag("Enemy"));
        }

 



        if ((currentAmmo == 0) && (backupAmmo != 0) && (!isReloading))
        {

            StartCoroutine(reload());

            audioSource.PlayOneShot(reloading, 0.1f);

        }
        


        

        if (Input.GetButtonDown("Fire1") && timer > fireRate && currentAmmo > 0 && !isReloading)
        {
            StartCoroutine(Fire()); 
            timer = 0;
            audioSource.PlayOneShot(shoot, 0.1f);

        }


        if ((Input.GetKeyDown(KeyCode.R)) && (backupAmmo > 0) && (currentAmmo < 5))
        {

            StartCoroutine(reload());
            audioSource.PlayOneShot(reloading, 0.1f);

        }

        currAmmo.text = "Ammo: " + currentAmmo.ToString() + " / " + backupAmmo.ToString();

       if(backupAmmo == startBackupAmmo)
        {

            AmmoButton.SetActive(false);


        }
        else
        {

            AmmoButton.SetActive(true);

        }
      

        
    }

    IEnumerator Fire()
    {

        anim.SetBool("isShooting", true);
        
        yield return new WaitForSeconds(fireRate);

        currentAmmo--;

        anim.SetBool("isShooting", false);

        


        GameObject effectIns = (GameObject)Instantiate (shotgunEffect, BulletExit.position, BulletExit.rotation);
		Destroy (effectIns, 2f);

        int i = 0;

        foreach(Quaternion quat in bullets)
        {
            bullets[i] = Random.rotation;
            GameObject b = Instantiate(Bullet, BulletExit.transform.position, BulletExit.transform.rotation);
            b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, bullets[i], spreadAngle);
            b.GetComponent<Rigidbody>().AddForce(b.transform.right * 5000.0f);
            i++;
        }

        audioSource.PlayOneShot(shoot);

    }






    IEnumerator reload()
    {
        //Debug.Log("Reloading");

        isReloading = true;

        anim.SetBool("isReloading", true);

        yield return new WaitForSeconds(reloadTime);

        anim.SetBool("isReloading", false);

        var shot = FullAmmo - currentAmmo;
        if(backupAmmo < shot)
        {
            currentAmmo = backupAmmo;

            backupAmmo = 0;
        }
        else
        {
            currentAmmo += shot;

            backupAmmo -= shot;
        }

       isReloading = false;
    }

    public void AddAmmo () {

     backupAmmo = startBackupAmmo;

    }

    public void UpgradeAmmoLimit (float amount) {

        startBackupAmmo += amount;
        backupAmmo += amount;

    }

    public void BuyAmmo (float amount) {

        if ((soulCount >= 500) && (backupAmmo < startBackupAmmo)) {

         backupAmmo = amount;
         
         GameObject.FindWithTag("SoulHolder").GetComponent<SoulHolder>().ReduceSouls (500);

         AmmoButton.SetActive (false);

      }


    }

}
