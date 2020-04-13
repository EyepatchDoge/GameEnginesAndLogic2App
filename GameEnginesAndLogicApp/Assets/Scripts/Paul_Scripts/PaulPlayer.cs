using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anime;
    public LayerMask groundDec;
    public float gDradious, flyVel;
    public Transform gDeteque;
    public bool Jump;
    public static bool Protection;
    //public GameObject abilityManager;
    public AbilityManager aManager;
    public GameObject startPlayerPos;
    public Vector3 startAsteroidPos;
    public GameObject[] asteroids;

    void Start()
    {
        aManager = GameObject.FindGameObjectWithTag("AbilityManager").GetComponent<AbilityManager>();
        
        startAsteroidPos = GameObject.FindGameObjectWithTag("AsteroidManager").transform.position;
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
        if(Protection == false)
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
        
        
    }

    // Sets timeScale to zero, call 
    public void PlayerDead()
    {
        GameManager.instance.ActivateShop();
        anime.SetTrigger("Replay");
        Time.timeScale = 0;
    }

    public void StartRun()
    {
        Time.timeScale = 1;
        rb.isKinematic = false;
        anime.SetTrigger("Replay");
        GameManager.instance.playDed = false;
        this.gameObject.transform.position = startPlayerPos.transform.position;
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
      
        foreach (GameObject asteroid in asteroids)
        {
            asteroid.SetActive(false);

        }
    }
}
