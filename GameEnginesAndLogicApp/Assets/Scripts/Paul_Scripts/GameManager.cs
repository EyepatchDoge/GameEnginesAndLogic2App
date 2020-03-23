using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this is the gamemanager script, holds the function for when player plays again/respawns after death/shop visit
/// and will hold the functionality for when the player acquires an ability/item to use during gameplay
/// etc
/// </summary>

public class GameManager : MonoBehaviour
{
    public GameObject Shop;
    public static GameManager instance;
    public bool playDed;
    public float Points;
    public PaulPlayer player;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playDed == true)
        {

            Shop.SetActive(true);
        }
        else if(playDed == false)
        {
            Shop.SetActive(false);
        }

    }

    public void KeepPlay()
    {
        player.BackToPlay();
        
    }
}
