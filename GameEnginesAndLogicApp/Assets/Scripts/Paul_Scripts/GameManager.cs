using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Shop;
    public static GameManager instance;
    public bool playDed;
    public float Points;

    // Start is called before the first frame update
    void Awake()
    {

        if (Shop != null)
        {
            Shop.SetActive(false);
        }
        
        instance = this;


        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRun()
    {
        //player.BackToPlay();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ActivateShop() 
    {
        Shop.SetActive(true);

    }
}
