using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourAbility : MonoBehaviour, IAbility
{
    public float hoam = 50;
    public Transform target;
    public GameObject Shield;
    public BoxCollider2D cirCollid;

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, hoam * Time.deltaTime);
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Debug.Log("player was found");
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            other.gameObject.SetActive(false);
            Shield.SetActive(false);
        }
    }

    public void Armour()
    {
        Shield.SetActive(true);
        cirCollid.enabled = true;
        
    }

    public void UseAbility()
    {
        Armour();
    }

}
