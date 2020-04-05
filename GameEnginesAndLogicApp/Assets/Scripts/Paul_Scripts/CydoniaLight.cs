using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CydoniaLight : MonoBehaviour
{
    public Transform target;
    public float hoam = 50;
    public static CydoniaLight instance;

    public void Start()
    {
        StartCoroutine(LightTimer());
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, hoam * Time.deltaTime);

    }

    public void Summon()
    {
        this.gameObject.SetActive(true);
    }

    IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(90f);
        this.gameObject.SetActive(false);
    }
}
