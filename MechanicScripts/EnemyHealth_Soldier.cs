using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth_Soldier : MonoBehaviour {

    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5, prefab6, prefab7, prefab8, prefab9, prefab10, prefab11, prefab12, prefab13, prefab14, prefab15;
    int whattoSpawn;
    float NextSpawn = 0f;


    //public Transform SoulDrop;
    public float shotgunDamage;
    public float soulDrop = 250f;

    public float startHealth = 100;
    public float health;

    public Image healthBar;

    void Start()
    {

        health = startHealth;

    }

    void Update()
    {


        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {

            Destroy(gameObject);

            if (Time.time > NextSpawn)
            {
                whattoSpawn = Random.Range(1, 15);
                Debug.Log(whattoSpawn);


                switch (whattoSpawn)
                {
                    case 1:
                        Instantiate(prefab1, transform.position, Quaternion.identity);
                        break;

                    case 2:
                        Instantiate(prefab2, transform.position, Quaternion.identity);
                        break;

                    case 3:
                        Instantiate(prefab3, transform.position, Quaternion.identity);
                        break;

                    case 4:
                        Instantiate(prefab4, transform.position, Quaternion.identity);
                        break;

                    case 5:
                        Instantiate(prefab5, transform.position, Quaternion.identity);
                        break;

                    case 6:
                        Instantiate(prefab6, transform.position, Quaternion.identity);
                        break;

                    case 7:
                        Instantiate(prefab7, transform.position, Quaternion.identity);
                        break;

                    case 8:
                        Instantiate(prefab8, transform.position, Quaternion.identity);
                        break;

                    case 9:
                        Instantiate(prefab9, transform.position, Quaternion.identity);
                        break;

                    case 10:
                        Instantiate(prefab10, transform.position, Quaternion.identity);
                        break;

                    case 11:
                        Instantiate(prefab11, transform.position, Quaternion.identity);
                        break;

                    case 12:
                        Instantiate(prefab12, transform.position, Quaternion.identity);
                        break;

                    case 13:
                        Instantiate(prefab13, transform.position, Quaternion.identity);
                        break;

                    case 14:
                        Instantiate(prefab14, transform.position, Quaternion.identity);
                        break;

                    case 15:
                        Instantiate(prefab15, transform.position, Quaternion.identity);
                        break;

                }

            GameObject.FindWithTag("Spawner").GetComponent<EnemyWaveSpawner_SS_Pagos>().EnemyTracker(1);

            }


            //Instantiate(SoulDrop);

            Debug.Log("Enemy has died!");

        }

    }

    public void TakeDamage(float amount)
    {

        healthBar.fillAmount = health / startHealth;

        health -= amount;

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {

            healthBar.fillAmount = health / startHealth;

            health -= shotgunDamage;

            Debug.Log("Shotgun Hit Enemy");

        }

        if (other.tag == "Base")
        {

            Destroy(gameObject);

        }
    }

    public void UpgradeShotgunDamage(float amount)
    {

        shotgunDamage += amount;

        return;

    }

}
