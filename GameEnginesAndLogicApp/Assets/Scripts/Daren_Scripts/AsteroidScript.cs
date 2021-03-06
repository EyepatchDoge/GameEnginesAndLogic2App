﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidScript : MonoBehaviour
{ 
    /// <summary>
    /// Daren's Script
    /// Adds a velocity towards the rigidbody and checks the trigger collider for when the asteroid leaves the boundary zone
    /// </summary>

    public Rigidbody2D rb;
    public Vector3 movementDir;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Adds a velocity to the asteroid
        rb.velocity = movementDir;
    }

    // Sets the asteroid to false when the asteroid leaves the screen
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "AsteroidBoundary")
        {
            gameObject.SetActive(false);
        }
    }
}
