using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //Create array to hold all sound effects
    public Sounds[] sounds;

    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            
        }
    }

    //When adding sound effects within a code
    public void Play (string name)
    {
       Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        //Code: FindObjectOfType<AudioManager>().Play("String Name");
    }

}
