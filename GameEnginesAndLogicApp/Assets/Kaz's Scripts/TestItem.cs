using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is a test run for items that can be purchased with in-game currency 
/// </summary>
public class TestItem : MonoBehaviour, IAbility
{
    public AudioSource celeberation;

   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayCelebrationClip();
        }
    }

    public void PlayCelebrationClip()
    {
        
            celeberation.Play();
            Destroy(gameObject, celeberation.clip.length);
    }


    public void UseAbility()
    {
        PlayCelebrationClip();
    }


}
