using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class newZombieAi : MonoBehaviour
{

    // Adding a new transform to hold the transform component of the player.
    Transform player;

    // A new animator variable called animator.
    Animator animator;

    // A gameobject where we hold the script container to referens it later on.
    private GameObject scriptContainer;

    // Adding a new navemeshagent called agent.
    NavMeshAgent agent;

    // a float variable to contain the rotation speed for the zombies.
    public float rotationSpeed = 10f;

    // an intager containing the health of the zombies.
    public int zombieHealth = 100;


    void Start()
    {
        // geting the animator from the gameobject the script is attatched to.
        animator = this.GetComponent<Animator>();

        // geting the Navmeshagent from the gameobject the script is attatched to.
        agent = this.GetComponent<NavMeshAgent>();

        // getting the player from the gameobject that contains the tag Player, in our case it is the XR rig.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        scriptContainer = GameObject.Find("ScriptContainer");

        //  when the zombie is instanced it will start running.
        animator.SetBool("running", true);
    }

    
    void Update()
    {
        // Set the destination to the player so the zombie can chase the player.
        agent.SetDestination(player.transform.position);

        // as long as the remaining distance is bigger that the agents stopping distance the zombie will keep running.
        // the stopping distance is set on the navmesh in the inspector.
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            // set the bool running to true, this will contact the animator and when the bool changes the animator will change to the running state.
            animator.SetBool("running", true);
            animator.SetBool("attacking", false);

        }
        else
        {
            // when the zombie is at the stoppingdistance it will stop running and start attacking.
            animator.SetBool("running", false);
            animator.SetBool("attacking", true);

            // Here we use the rotate function to rotate the zombie towards the player when attacking.
            RotateTowards(player.transform);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // if the zombies collider is hit by a object with the tag bullet, decrease the zombie health by 35, 
        if (collision.gameObject.tag == "Bullet")
        {
            zombieHealth = zombieHealth - 35;

            //then check if the zombies health is at 0
            if (zombieHealth <= 0)
            {

                // if it is less than zero set it back to zero.
                zombieHealth = 0;

                // run the zombie death function
                ZombieDeath();
            }

        }

        // if the zombies collider is hit by a object with the tag bullet, decrease the zombie health by 35, 
        else if (collision.gameObject.tag == "Blade")
        {
            zombieHealth = zombieHealth - 35;

            //then check if the zombies health is at 0
            if (zombieHealth <= 0)
            {
                // if it is less than zero set it back to zero.
                zombieHealth = 0;

                // run the zombie death function
                ZombieDeath();
            }

        }



    }

    void ZombieDeath()
    {
        // Reference to the gamemanager script to increase the number of zombies killed.
      //  scriptContainer.GetComponent<GameManager>().IncreaseZombiesKilled();

        // Play the animation ZombieDeath that is in the animotor.
        animator.Play("ZombieDeath");

        // change the Zombies speed so it won't follow you after it has died.
        agent.speed = 0;
        
        // GetComponent<NavMeshAgent>().enabled = false;
    }

    // Rotate towards player function.
    private void RotateTowards(Transform target)
    {
        // create a new Vector 3 that contains the players location.
        Vector3 direction = (target.position - transform.position).normalized;

        // Create a new Quaternion with look rotation that will make the zombie turn against the player direction. 
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // transform the rotation towards the player with the rotation speed.
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
