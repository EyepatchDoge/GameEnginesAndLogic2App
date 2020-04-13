using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public InGameCurrencySO spaceCoins;
    public Text coinsAmount, resultAmount;
    public static UIHandler instance;
    public float resultCoins;
    public GameObject pauseButton, resultscren;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void SetDef()
    {
        resultCoins = 0;
        resultscren.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coinsAmount.text = Mathf.RoundToInt(spaceCoins.currencyAmount).ToString();
        spaceCoins.currencyAmount += Time.deltaTime;
        resultCoins += Time.deltaTime;
        resultAmount.text = Mathf.RoundToInt(resultCoins).ToString();

        if (GameManager.instance.playDed == false)
        {  
            pauseButton.SetActive(true);
            
        }
        else if(GameManager.instance.playDed == true)
        {
            
            pauseButton.SetActive(false);
        }

        //remember to add rankiogs to the result amount later
    }
}
