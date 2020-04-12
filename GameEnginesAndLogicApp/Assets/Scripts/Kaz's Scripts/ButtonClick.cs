using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Kas
///  This script will be for purchasing anything with real money
/// </summary>

public class ButtonClick : MonoBehaviour
{

    public InGameCurrencySO spaceCoins;
     public Text coinAmount;
    // coinAmount.text = spaceMoney.currencyAmount.ToString();

     //if purchhase is sucessfull, reward the player the amount of money they are owed
    public void PurchaseCoins(int amount)
    {
        spaceCoins.currencyAmount += amount;
         coinAmount.text = spaceCoins.currencyAmount.ToString();
    }

 

}
