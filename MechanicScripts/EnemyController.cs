using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {


    //Animation Related Code at top = testing

    public Animation anim;

    public WrapMode wrapMode;




    private int wheretogo;

    private Transform Base;
    
    private Transform location;
    NavMeshAgent agent;
    GameObject BaseDome;

    private float NextSpawn = 1f;

    private float destNum;

    // Use this for initialization
    void Start ()
    {
        //call the animation
        anim = GetComponent<Animation>();
        //set animation to loop since it is a single floating animation
        anim.wrapMode = WrapMode.Loop;
        //play the animation(s)
        anim.Play();

        BaseDome = GameObject.FindGameObjectWithTag("Base");
        //baseHealth = BaseDome.GetComponent<BaseController>();
        Base = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();


    Transform location1 = GameObject.FindGameObjectWithTag("location1").GetComponent<Transform>();
    Transform location2 = GameObject.FindGameObjectWithTag("location2").GetComponent<Transform>();
    Transform location3 = GameObject.FindGameObjectWithTag("location3").GetComponent<Transform>();
    Transform location4 = GameObject.FindGameObjectWithTag("location4").GetComponent<Transform>();
    Transform location5 = GameObject.FindGameObjectWithTag("location5").GetComponent<Transform>();
    Transform location6 = GameObject.FindGameObjectWithTag("location6").GetComponent<Transform>();

    destNum = Random.Range (1, 6);

   if (destNum == 1) {

       agent.destination = location1.position;

   }

    if (destNum == 2) {

        agent.destination = location2.position;
    }

    if (destNum == 3) {

        agent.destination = location3.position;

    }

    if (destNum == 4) {

        agent.destination = location4.position;
   
    }
    
    if (destNum == 5) {

        agent.destination = location5.position;

    }
 
    if (destNum == 6) {

        agent.destination = location6.position;

    }
 }	

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bullet")
        {
           
            Destroy(col.gameObject);
        }

        if(col.gameObject.name == "BaseHealth")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
       

    }

    // Update is called once per frame
    void Update ()
    {

	}

}
