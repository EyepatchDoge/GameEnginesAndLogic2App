using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Spawn boundaries for new asteroids
    public float minSpawnPosY;
    public float maxSpawnPosY;

    ObjectPooler objectPooler;
 

    public IEnumerator AsteroidSpawner()
    {
        objectPooler.SpawnFromPool("Asteroid", new Vector3(transform.position.x, Random.Range(minSpawnPosY, maxSpawnPosY), transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1,2));
        StartCoroutine("AsteroidSpawner");
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance; 
        StartCoroutine("AsteroidSpawner");
    }

    void FixedUpdate()
    {

    }
}
