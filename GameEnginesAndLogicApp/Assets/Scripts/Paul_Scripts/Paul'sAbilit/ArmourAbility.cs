using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourAbility : MonoBehaviour, IAbility
{

    public void Armour()
    {
        PaulPlayer.instance.Protection = true;
    }

    public void UseAbility()
    {
        Armour();
    }

}
