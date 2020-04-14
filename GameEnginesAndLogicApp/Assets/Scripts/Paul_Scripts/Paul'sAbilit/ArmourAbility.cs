using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourAbility : MonoBehaviour, IAbility
{
    public float hoam = 50;
    public Transform target;
    public GameObject Shield;
    public BoxCollider2D cirCollid;
    //code done by Paul Crewe
    public void Start()
    {
        //if not set then finds the location and sets that location via FIND
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("ArmourTran").GetComponent<Transform>();
            Debug.Log("player was found");
        }
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, hoam * Time.deltaTime);
        
       //follows the player
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if the shield gets hit by an asteroid, will turn off asteroid and turn off shield's sprite renderer and collider
        if(other.gameObject.tag == "Asteroid")
        {
            other.gameObject.SetActive(false);
            Shield.SetActive(false);
            cirCollid.enabled = false;
        }
    }

    public void Armour()
    {
        //when player buys shield this function will activate it
        Shield.SetActive(true);
        cirCollid.enabled = true;
    }

    public void UseAbility()
    {
        Armour();
    }

}
