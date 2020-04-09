using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public GameObject shop;
    public PaulPlayer player;
    public bool playDed; //cydActive, armourActive;
    public float Points;
    private Scene scene;
    public static GameManager instance;
    public AbilityManager aManager;
    public InGameCurrencySO spaceCoins;
    public Text coinsAmount;
    #endregion

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


        //coinsAmount.text = spaceCoins.currencyAmount.ToString();
        aManager = GameObject.FindGameObjectWithTag("AbilityManager").GetComponent<AbilityManager>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        #region Gets Reference to AbilityManager (Disabled)
        /*if(GameObject.Find("AbilityManager") == null)
        {
            Debug.Log("AbilityManager does not exists");
        }
        else
        {
            aManager = GameObject.Find("AbilityManager");
            aManagerScript = aManager.GetComponent<AbilityManager>();
        }*/
        #endregion

        #region Checks for shop in each loaded scene
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
        #endregion

        #region Looks for player in loaded scene
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.Log("Player not found in scene");
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PaulPlayer>();
            
        }
        #endregion

        #region Finds references for Cydonia's Light (Disabled)
        /*if (GameObject.FindGameObjectWithTag("Light") != null)
        {
            Debug.Log("Light was found");
            CydLight = GameObject.FindGameObjectWithTag("Light");
        }
        else
        {
            Debug.Log("light was MIA");
        }*/
        #endregion

        #region Checks for ability purchases
        //if (cydActive == true)
        //{
        //    //player.GetComponent<CydoniaLight>().enabled = true;
        //    //CydoniaLight.Shine = true;
        //}
        //if (armourActive == true)
        //{
        //    Debug.Log("player is Armoured");
        //    PaulPlayer.Protection = true;
        //}
        #endregion
    }
    //switched the armour ability from being apart of player's animations to just a simple gameobject :)
    public void PlayerArmmoured()
    {
        Debug.Log("its dangerous to go raw use pretection");
        //armourActive = true;
        //TempArmour.SetActive(true);
    }

    public void TurnOnShine()
    {
        Debug.Log("God said turn the lights on");
        //cydActive = true;
    }

    public void StartGame()
    {
        Debug.Log("Game started");
        //Time.timeScale = 1;
        //SceneManager.LoadScene(1);
        aManager.ApplyAbilities();
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
