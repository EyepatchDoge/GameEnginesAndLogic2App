using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// kas
/// script that will check the so of the space coins and deactivate if coins aren't needed 
/// </summary>

public class VideoAdsManager : MonoBehaviour
{
    public GameObject video;
    public InGameCurrencySO spaceCoins;

    public void CheckCoins()
    {
        if(spaceCoins.currencyAmount <= 20)
        {
            video.SetActive(true);
        }

        if(spaceCoins.currencyAmount >= 21)
        {
            video.SetActive(false);
        }
    }

}
