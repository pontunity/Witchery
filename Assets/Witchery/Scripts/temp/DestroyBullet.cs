using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // if the target collider is hit by a object with the tag bullet, decrease the target health by 35, 


        if (collision.gameObject.tag == "Enemy")
        {          

                Destroy(this.gameObject);
   
        }

    }
    // Update is called once per frame
    void Update()
    {
        DestroyObjectDelayed();
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }
}
