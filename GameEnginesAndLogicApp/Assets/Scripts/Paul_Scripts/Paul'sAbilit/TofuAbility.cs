using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuAbility : MonoBehaviour, IAbility
{
    public void UseAbility()
    {
        Skins.instance.SkinChooser.SetActive(true);
    }
}
