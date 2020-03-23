using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public void KeepPlay()
    {
        player.BackToPlay();
        
    }

    public void ActivateShop() 
    {
            Shop.SetActive(true);
    }
}
