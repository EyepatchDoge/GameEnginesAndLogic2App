using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
