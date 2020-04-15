using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Paul and Daren's Script
    /// </summary>
    #region Variables
    public InGameCurrencySO spaceCoins;
    public GameObject shop;
    public PaulPlayer player;
    public bool playDed, Gamestart;
    public float resultCoins;
    private Scene scene;
    public static GameManager instance;
    public AbilityManager aManager;
    //done by both Paul and Daren
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        //sets to singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //sets the player death bool to false on load(cause it doen't make sense for the player to die at the beginning of the game
        playDed = false;

    }

    public void StartGame()
    {
        //loads scene/ sets gameplay scene
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Gamestart = true;
    }

    public void Update()
    {
        //will update the coins whether or not the bool is set when gameplay scene loaded
        if(Gamestart == true)
        {
            spaceCoins.currencyAmount += Time.deltaTime;
            resultCoins += Time.deltaTime;
        }
        
    }

    void OnEnable()
    {
        //parameters needed for the onSceneLoaded void
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        //parameters needed for the onSceneLoaded void
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        //all of what you see here is to find the game objects needed for the game to function properly on scene load
        //things like the player and the shop and ability manager are all found here without the need to drag and drop
        #region Gets Reference to AbilityManager 
        if(GameObject.FindGameObjectWithTag("AbilityManager") == null)
        {
            Debug.Log("AbilityManager does not exists");
        }
        else
        {
            aManager = GameObject.FindGameObjectWithTag("AbilityManager").GetComponent<AbilityManager>();
            Debug.Log("AbilityManager does exists");
        }
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
    }

    // Pulls up shop and results tab when player dies
    public void ActivateShop()
    {
        //will activate shop when player dies and also sets the playDed bool to false to for the UIHandler
        playDed = true;
        UIHandler.instance.resultscren.SetActive(true);
        shop.SetActive(true);
    }
}
