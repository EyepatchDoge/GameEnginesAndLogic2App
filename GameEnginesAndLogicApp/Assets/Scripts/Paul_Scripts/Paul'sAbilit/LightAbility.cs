using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbility : MonoBehaviour, IAbility
{

    public void ProtectTheGhild()
    {
        CydoniaLight.instance.Summon();
    }

    public void UseAbility()
    {
        ProtectTheGhild();
    }
}
