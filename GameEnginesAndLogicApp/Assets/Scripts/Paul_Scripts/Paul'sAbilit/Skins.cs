using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    //sets the buttons to switch characters to true, etc
    public GameObject SkinChooser;
    public static Skins instance;

    public void Awake()
    {
        //for reference to the IAbility portion to activate script
        instance = this;
    }   
}
