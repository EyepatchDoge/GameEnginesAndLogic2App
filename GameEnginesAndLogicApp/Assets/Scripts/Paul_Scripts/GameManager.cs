using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject shop, CydLight;
    public bool playDed;
    public float Points;
    private Scene scene;
    public static GameManager instance;

    public InGameCurrencySO spaceCoins;
    public Text coinsAmount;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        coinsAmount.text = spaceCoins.currencyAmount.ToString();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded()
    {
        if (GameObject.FindGameObjectWithTag("Shop") == null)
        {
            Debug.Log("Shop does not exists");
            return;
        }
        else
        {
            Debug.Log("Shop was found");
            shop = GameObject.FindGameObjectWithTag("Shop");
            shop.SetActive(false);
        }
    }
 
    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        if (GameObject.FindGameObjectWithTag("Shop") != null)
        {
            Debug.Log("Shop was found");
            shop = GameObject.FindGameObjectWithTag("Shop");
            shop.SetActive(false);
        }
        else
        {
            Debug.Log("Shop does not exists");
            return;
        }
        if(GameObject.FindGameObjectWithTag("Light") != null)
        {
            Debug.Log("Light was found");
            CydLight = GameObject.FindGameObjectWithTag("Light");
            CydLight.SetActive(false);
        }
        else
        {
            Debug.Log("light was MIA");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for testing the light out
        if (Input.GetKeyDown(KeyCode.P))
        {
            CydLight.SetActive(true);
            CydoniaLight.Shine = true;
        }
    }

    public void PlayerArmmoured()
    {
        Debug.Log("player is Armoured");
        PaulPlayer.Protection = true;
    }

    public void TurnOnShine()
    {
        CydLight.SetActive(true);
        CydoniaLight.Shine = true;
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
        shop.SetActive(true);
        Debug.Log("Scene was reloaded");
    }
}
