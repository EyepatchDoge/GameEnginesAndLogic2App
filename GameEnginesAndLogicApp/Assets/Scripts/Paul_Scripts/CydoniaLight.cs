using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CydoniaLight : MonoBehaviour, IAbility
{
    public float hoam = 50;
    public Transform target;
    public CircleCollider2D cirCollid;
    public SpriteRenderer sp;

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, hoam * Time.deltaTime);

        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
    }

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
