using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    //Animation Related Code at top = testing

    public Animation anim;

    public WrapMode wrapMode;

    //end animation code

    NavMeshAgent agent;

    private Transform Base;
    private float NextSpawn = 1f;

    private float destNum;

    private float damp = 5f;

    // Use this for initialization
    void Start ()
    {
        //animation code
        //call the animation
        //anim = GetComponent<Animation>();
        //set animation to loop since it is a single floating animation
        //anim.wrapMode = WrapMode.Loop;
        //play the animation(s)
        //anim.Play();
//end animation code

        //BaseDome = GameObject.FindGameObjectWithTag("Base");
        //baseHealth = BaseDome.GetComponent<BaseController>();
        Base = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
		agent.destination = Base.position;
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

        var rotationAngle = Quaternion.LookRotation ( Base.position - transform.position);
         transform.rotation = Quaternion.Slerp ( transform.rotation, rotationAngle, Time.deltaTime * damp);

	}

}