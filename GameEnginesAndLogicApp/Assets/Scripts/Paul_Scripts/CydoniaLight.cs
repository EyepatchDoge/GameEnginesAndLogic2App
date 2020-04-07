using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CydoniaLight : MonoBehaviour
{
    public Transform target;
    public float hoam = 50;
    public static bool Shine;
    //public CircleCollider2D cirCollid;
    //public SpriteRenderer sp;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, hoam * Time.deltaTime);

        if (Shine == true)
        {
            Summon();
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
        yield return new WaitForSeconds(90f);
        this.gameObject.SetActive(false);
    }
}
