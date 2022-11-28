using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTargetDamage : MonoBehaviour
{
    public int targetHealth = 20;
    public GameObject earthParticleSystem;

    void OnCollisionEnter(Collision collision)
    {
        // if the target collider is hit by a object with the tag bullet, decrease the target health by 35, 
     
        
      if (collision.gameObject.tag == "EarthBullet")
         {
            Debug.Log("Target Hit");
            targetHealth = targetHealth - 35;

            //then check if the zombies health is at 0
            if (targetHealth <= 0)
            {
                Debug.Log("Target Dead"); 
                // if it is less than zero set it back to zero.
                targetHealth = 0;

                earthParticleSystem.SetActive(true);

                Destroy(this.gameObject);
                // run the zombie death function
                // ZombieDeath();


            }

         }

    }
    void ZombieDeath()
    {
        // Reference to the gamemanager script to increase the number of zombies killed.
       // scriptContainer.GetComponent<GameManager>().IncreaseZombiesKilled();

        // Play the animation ZombieDeath that is in the animotor.
       // animator.Play("ZombieDeath");

        // change the Zombies speed so it won't follow you after it has died.
       // agent.speed = 0;

        // GetComponent<NavMeshAgent>().enabled = false;
    }

}
