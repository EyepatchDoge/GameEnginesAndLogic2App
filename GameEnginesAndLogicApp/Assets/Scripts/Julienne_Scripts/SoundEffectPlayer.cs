using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
   public void SpaceCoins()
    {
        FindObjectOfType<AudioManager>().Play("Shop1");
    }

    public void PowerUps()
    {
        FindObjectOfType<AudioManager>().Play("Shop2");
    }

    public void startGame()
    {
        FindObjectOfType<AudioManager>().Play("Start");
    }

}
