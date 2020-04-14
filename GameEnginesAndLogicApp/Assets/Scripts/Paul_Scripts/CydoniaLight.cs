using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CydoniaLight : MonoBehaviour, IAbility
{
    public float hoam = 50;
    public Transform target;
    public CircleCollider2D cirCollid;
    public SpriteRenderer sp;

    public void Start()
    {
        //if the target is not set then finds the target based on tag and gets transform
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Debug.Log("Light has found the player");
        }
    }

    public void Update()
    {
        //follows player
        transform.position = Vector2.MoveTowards(transform.position, target.position, hoam * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //if the player collides with an asteroid with the light turned on, the asteroid will get turned off
        if (other.gameObject.tag == "Asteroid")
        {
           other.gameObject.SetActive(false);
        }
        
    }

    public void Summon()
    {
        //when buaght will set variables to active
        StartCoroutine(LightTimer());
        cirCollid.enabled = true;
        sp.enabled = true;
        
    }

    IEnumerator LightTimer()
    {
        //will turn off collider and sprite renderer when 10 secs have reached
        yield return new WaitForSeconds(10f);
        cirCollid.enabled = false;
        sp.enabled = false;
    }

    public void UseAbility()
    {
        Summon();
        
    }
    //done by Paul Crewe
}
