using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    // List of pools
    public List<Pool> pools;

    // Declaring a dictionary
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton Declaration
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
        CreateDictionary();
    }
    #endregion

    // Start is called before the first frame update
    void CreateDictionary()
    {
        // Creates a new empty dictonary
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // Adding the list of pools in the dictionary
        foreach (Pool pool in pools)
        {
            // Creates a queue of gameobjects
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // Creates all objects in list and add it to the queue
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            // Adds it the the dictionary
            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        // Checks if an incorrect tag is given
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }

        // Dequeues the object that is being spawned
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        // Puts the object spawned back to the queue
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
