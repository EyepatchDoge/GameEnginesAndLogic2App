﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  This script will be for purchasing anything with real money
/// </summary>

public class ButtonClick : MonoBehaviour
{

    public InGameCurrencySO spaceCoins;
    // public Text coinAmount;
    // coinAmount.text = spaceMoney.currencyAmount.ToString();

    public void PurchaseFiftyCoins()
    {
        spaceCoins.currencyAmount += 50;
        // coinAmount.text = spaceMoney.currencyAmount.ToString();
    }

   

}