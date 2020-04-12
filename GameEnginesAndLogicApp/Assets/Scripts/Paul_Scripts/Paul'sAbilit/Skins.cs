using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour, IAbility
{
    public GameObject SkinChooser;

    public void TurnOnButtons()
    {

        SkinChooser.SetActive(true);
    }

    public void UseAbility()
    {
        TurnOnButtons();
    }
}
