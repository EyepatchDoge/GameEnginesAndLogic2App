using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CydoniaLight : MonoBehaviour, IAbility
{
    //public Transform target;
    
    public float hoam = 50;
    public static bool Shine;
    
    //public CircleCollider2D cirCollid;
    //public SpriteRenderer sp;

    private void Update()
    {
            Debug.Log("do do");

        if (Shine == true)
        {
            //Summon();
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (enabled)
        {
            if (other.gameObject.tag == "Asteroid")
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    public void Summon()
    {
        //cirCollid.enabled = true;
        //sp.enabled = true;
        //this.gameObject.SetActive(true);
        StartCoroutine(LightTimer());
        
    }

    IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(9f);
        this.gameObject.SetActive(false);
    }

    public void UseAbility()
    {
        
        GameManager.instance.TurnOnShine();
        GameManager.instance.cydActive = true;
    }
}
