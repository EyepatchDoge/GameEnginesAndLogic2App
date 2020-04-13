using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulPlayer : MonoBehaviour
{
    #region Variables
    public Rigidbody2D rb;
    public Animator anime;
    public LayerMask groundDec;
    public float gDradious, flyVel;
    public Transform gDeteque;
    public bool Jump;
    public static bool Protection;
    public AbilityManager aManager;
    public GameObject startPlayerPos;
    public GameObject[] asteroids;
    #endregion

    // Gets references to Ability Manager
    void Start()
    {
        aManager = GameObject.FindGameObjectWithTag("AbilityManager").GetComponent<AbilityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D isGrounded = Physics2D.OverlapCircle(gDeteque.position, gDradious, groundDec);
        anime.SetBool("Grounded", isGrounded);

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);

            //detects if the player is touching the screen and flies the player up
           if (myTouch.phase == TouchPhase.Stationary)
           {
                rb.velocity = Vector2.up * flyVel;
                anime.SetBool("Flying", true);
           }
                //detects when the player stops touching the screen and lets the player fall
           else if (myTouch.phase == TouchPhase.Ended)
           {
                 //rb.velocity = Vector2.up * flyVel;
                 anime.SetBool("Flying", false);
           }
        }

        //this is for testing purposes but does the same thing
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.up * flyVel;
            anime.SetBool("Flying", true);
        }
        else
        {
            anime.SetBool("Flying", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(gDeteque.position, gDradious);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Asteroid")
            {
                // Sets player to isKinematic and velocity to zero
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;

                // Plays death animation
                anime.SetTrigger("Ded");

                // Disables asteroid that player collided with
                collision.gameObject.SetActive(false);
            }
        
        
        
    }

    // Sets timeScale to zero
    public void PlayerDead()
    {
        GameManager.instance.ActivateShop();
        anime.SetTrigger("Replay");
        Time.timeScale = 0;
    }

    // Resets the game without reloading scene
    public void StartRun()
    {
        Time.timeScale = 1;
        rb.isKinematic = false;
        anime.SetTrigger("Replay");
        GameManager.instance.playDed = false;

        // Resets the player back to its recorded start pos
        this.gameObject.transform.position = startPlayerPos.transform.position;

        // Finds all asteroids active in scene
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
      
        // Sets all current asteroids active to false
        foreach (GameObject asteroid in asteroids)
        {
            asteroid.SetActive(false);
        }
    }
}
