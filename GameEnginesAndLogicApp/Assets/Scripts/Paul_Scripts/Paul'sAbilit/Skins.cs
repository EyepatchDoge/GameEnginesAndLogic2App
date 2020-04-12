using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public GameObject SkinChooser;
    public static Skins instance;

    public void Awake()
    {
        instance = this;
    }

    //public void TurnOnButtons()
    //{
        
    //    SkinChooser.SetActive(true);
    //}

    
}
