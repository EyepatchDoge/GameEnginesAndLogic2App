using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    /// <summary>
    /// Daren's Script
    /// </summary>

    #region Variables
    // Spawn boundaries for new asteroids
    public float minSpawnPosY;
    public float maxSpawnPosY;
    
    public float playerPos;
    public float playerPosOffset;
    public string poolTag1;
    public string poolTag2;
    ObjectPooler objectPooler;
    #endregion

    // Spawns asteroids in a random location (between a defined max and min y position) between 1-2 seconds
    public IEnumerator AsteroidSpawner()
    {
        yield return new WaitForSeconds(Random.Range(1,2));
        objectPooler.SpawnFromPool(poolTag1, new Vector3(transform.position.x, Random.Range(minSpawnPosY, maxSpawnPosY), transform.position.z), Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Asteroid");
        // Restart the coroutine   
        StartCoroutine("AsteroidSpawner");
        
    }

    // Spawns asteroids in a random offset of the player between 0.8-1.3 seconds
    public IEnumerator AsteroidSpawner2()
    {
        // Checks the player position
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position.y;

        // If player is at the top boundary
        if (playerPos < -1.5)
        {
            
            objectPooler.SpawnFromPool(poolTag2, new Vector3(transform.position.x, playerPos + playerPosOffset, transform.position.z), Quaternion.identity);
        }
        // If the player is at the bottom boundary
        else if (playerPos > 5.6f)
        {
           
            objectPooler.SpawnFromPool(poolTag2, new Vector3(transform.position.x, playerPos - playerPosOffset, transform.position.z), Quaternion.identity);
        }
        // Randomize its spawn position from either above the player or below
        else
        {
           
            objectPooler.SpawnFromPool(poolTag2, new Vector3(transform.position.x, Random.Range((playerPos - playerPosOffset), (playerPos + playerPosOffset)), transform.position.z), Quaternion.identity);
        }

        yield return new WaitForSeconds(Random.Range(.5f, .9f));

        // Restart the coroutine
        StartCoroutine("AsteroidSpawner2");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Sets objectPooler to the current existing instance of ObjectPooler
        objectPooler = ObjectPooler.Instance;

        // Starts the coroutines for both sets of asteroids
        StartCoroutine("AsteroidSpawner");
        StartCoroutine("AsteroidSpawner2");
        
    }
}
