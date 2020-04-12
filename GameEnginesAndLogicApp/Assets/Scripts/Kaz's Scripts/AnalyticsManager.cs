using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public void PurchaseShield()
    {
        Analytics.CustomEvent("Shield Purchased");
    }

    public void PurchaseLight()
    {
        Analytics.CustomEvent("Light Purchased");
    }

    public void FiveHundredSpaceCoins()
    {
        Analytics.CustomEvent("500 Space coins purchased");
    }
}
