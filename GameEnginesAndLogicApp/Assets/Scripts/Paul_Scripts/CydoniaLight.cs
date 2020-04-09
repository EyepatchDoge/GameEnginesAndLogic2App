using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CydoniaLight : MonoBehaviour, IAbility
{
    
    public CircleCollider2D cirCollid;
    public SpriteRenderer sp;

    void OnTriggerEnter2D (Collider2D other)
    {
        
        if (other.gameObject.tag == "Asteroid")
        {
           other.gameObject.SetActive(false);
        }
        
    }

    public void Summon()
    {
        
        StartCoroutine(LightTimer());
        cirCollid.enabled = true;
        sp.enabled = true;
        
    }

    IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(9f);
        cirCollid.enabled = false;
        sp.enabled = false;
    }

    public void UseAbility()
    {
        Summon();
        
    }
}
