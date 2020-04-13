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

        playDed = false;

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
        playDed = true;
        UIHandler.instance.resultscren.SetActive(true);
        shop.SetActive(true);
    }
}
