using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidScript : MonoBehaviour
{ 
    public Rigidbody2D rb;
    public Vector3 movementDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movementDir;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "AsteroidBoundary")
        {
            gameObject.SetActive(false);
        }
        else if(other.tag == "Light")
        {
            gameObject.SetActive(false);
        }
    }
}
