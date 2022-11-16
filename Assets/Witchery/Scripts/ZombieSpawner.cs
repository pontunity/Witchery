using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // Creating a gameobject array named Zombie prefab.
    public GameObject[] zombiePrefab;

    // A float that will change how far from the spawn location zombies can spawn.
    public float spawnRadius;

    // An intager that holds the delay in seconds. 
    public int delay = 5;

    // 
    public int goalNumberOfZombies;

    public int numberOfZombies = 0;

    void Start()
    {
        // When the object is enabled we start the couroutine for spawning zombies.
        StartCoroutine(spawnZombieCouroutine());
    }


    void Update()
    {

    }

    // The couroutine
    IEnumerator spawnZombieCouroutine()
    {
        
        // as long as the current number of zombies have not reached the total
        while (numberOfZombies < goalNumberOfZombies)
        {
            // create an intager named rand that will use the zombiePrefab arrays range to randomize what zombie will spawn.
            int rand = Random.Range(0, zombiePrefab.Length);

            // creates a new vector 3 that contains the position where the zombies should be spawned, the inside unitysphere creates a sphere around the object and it is multiplied with the spawn radius.
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * spawnRadius;

            // Instantiating the zombies with the rand variable so different zombies spawn, and also at a randomPoint around the spawn loaction, with the rotation of the prefab.
            Instantiate(zombiePrefab[rand], randomPoint, Quaternion.identity);

            // increases the number of zombies.
            numberOfZombies++;

            // after a zombie is spawned we have a delay so they dont spawn at the same time.
            yield return new WaitForSeconds(delay);
        }
        // after we reached the goal number of zombies then we stop the coroutine.
        StopCoroutine(spawnZombieCouroutine());
    }
}
