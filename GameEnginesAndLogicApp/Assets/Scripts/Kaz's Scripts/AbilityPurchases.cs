using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this is the purchaser script that will be used in the store for in game currency purchases
/// </summary>


public class AbilityPurchases : MonoBehaviour
{
    public InGameCurrencySO spaceMoney;
    public AbilityManager aManager;
    public Text coinAmount;
    public Text warningText;

    public void BuyAbility(AbilitySO SO)
    {
        //if the player has enough money as specified in the SO,  
        if(spaceMoney.currencyAmount >= SO.cost && aManager.abilityDictionary[SO] == false)
        {

            warningText.text = ("You have purchased the " + SO.name);
           
            //make the ability turn to true so it is useable once the game starts
            aManager.UpdateDictonary(SO, true);

            //and take away the money that is owed
            spaceMoney.currencyAmount -= SO.cost;

           coinAmount.text = spaceMoney.currencyAmount.ToString(); 

        }

        else if(spaceMoney.currencyAmount < SO.cost)
        {
            warningText.text = "You do not have enough money, please puchase more, play more or watch an ad";
        }


        else if(aManager.abilityDictionary[SO] == true)
        {
            warningText.text = "You have already purchased this ability";
        }
    }
}
