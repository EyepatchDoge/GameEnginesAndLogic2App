using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbility : MonoBehaviour, IAbility
{

    public void ProtectTheGhild()
    {
        GameManager.instance.TurnOnShine();
    }

    public void UseAbility()
    {
        ProtectTheGhild();
    }
}
