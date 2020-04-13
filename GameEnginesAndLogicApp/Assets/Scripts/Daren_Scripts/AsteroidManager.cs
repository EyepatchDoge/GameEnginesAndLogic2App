using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Spawn boundaries for new asteroids
    public float minSpawnPosY;
    public float maxSpawnPosY;
    
    public float playerPos;
    public float playerPosOffset;
    public string poolTag1;
    public string poolTag2;
    ObjectPooler objectPooler;
 
    // Spawns asteroids in a random location between 1-2 seconds
    public IEnumerator AsteroidSpawner()
    {
        yield return new WaitForSeconds(Random.Range(1,2));
        objectPooler.SpawnFromPool(poolTag1, new Vector3(transform.position.x, Random.Range(minSpawnPosY, maxSpawnPosY), transform.position.z), Quaternion.identity);

        // Restart the coroutine   
        StartCoroutine("AsteroidSpawner");
        
    }

    // Spawns asteroids in a random offset of the player between 0.8-1.3 seconds
    public IEnumerator AsteroidSpawner2()
    {
        yield return new WaitForSeconds(Random.Range(.8f, 1.3f));

        if (playerPos < -1.5 && playerPos > -1.6)
        {
            objectPooler.SpawnFromPool(poolTag2, new Vector3(transform.position.x, playerPos, transform.position.z), Quaternion.identity);
        }
        else
        {
        objectPooler.SpawnFromPool(poolTag2, new Vector3(transform.position.x, Random.Range((playerPos - playerPosOffset), (playerPos +playerPosOffset)), transform.position.z), Quaternion.identity);
        }

        // Restart the coroutine
        StartCoroutine("AsteroidSpawner2");
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine("AsteroidSpawner");
        StartCoroutine("AsteroidSpawner2");
    }

    void FixedUpdate()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position.y;
    }
}
