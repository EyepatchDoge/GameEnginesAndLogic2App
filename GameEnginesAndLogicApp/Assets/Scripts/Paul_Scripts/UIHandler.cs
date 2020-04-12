using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public InGameCurrencySO spaceCoins;
    public Text coinsAmount;
    public static UIHandler instance;
    public GameObject pauseButton;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsAmount.text = Mathf.RoundToInt(spaceCoins.currencyAmount).ToString();
        spaceCoins.currencyAmount += Time.deltaTime;

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
