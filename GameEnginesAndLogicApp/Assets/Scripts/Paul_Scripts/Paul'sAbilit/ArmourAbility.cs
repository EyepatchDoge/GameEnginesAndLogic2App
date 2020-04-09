using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourAbility : MonoBehaviour, IAbility
{
    public GameObject Shield;
    public BoxCollider2D cirCollid;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.SetActive(false);
            Shield.SetActive(false);
        }
    }

    public void Armour()
    {
        Shield.SetActive(true);
        cirCollid.enabled = true;
        //GameManager.instance.PlayerArmmoured();
    }

    public void UseAbility()
    {
        Armour();
    }

}
