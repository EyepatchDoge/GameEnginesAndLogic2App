using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourAbility : MonoBehaviour, IAbility
{

    public void Armour()
    {
        GameManager.instance.PlayerArmmoured();
    }

    public void UseAbility()
    {
        Armour();
    }

}
