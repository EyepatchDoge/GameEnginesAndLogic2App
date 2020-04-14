using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    //public InGameCurrencySO spaceCoins;
    public Text coinsAmount, resultAmount;
    public static UIHandler instance;
    //public float resultCoins;
    public GameObject pauseButton, resultscren;
    // all of this code is done by Paul
    public void Awake()
    {
        //makes singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    // Start is called before the first frame update
    public void SetDef()
    {
        GameManager.instance.resultCoins = 0;
        resultscren.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //updates UI and handles some UI assets
        coinsAmount.text = Mathf.RoundToInt(GameManager.instance.spaceCoins.currencyAmount).ToString();
        resultAmount.text = Mathf.RoundToInt(GameManager.instance.resultCoins).ToString();

        if (GameManager.instance.playDed == false)
        {  
            pauseButton.SetActive(true);
            
        }
        else if(GameManager.instance.playDed == true)
        {
            
            pauseButton.SetActive(false);
        }

        
    }
}
