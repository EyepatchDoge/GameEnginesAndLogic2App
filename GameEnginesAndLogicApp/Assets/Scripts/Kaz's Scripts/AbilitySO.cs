﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//createda SO for abilities to use in ability manager and purchases
[CreateAssetMenu(fileName = "AbilitySO", menuName = "ScriptableObjects/Abilities", order = 2)]
public class AbilitySO : ScriptableObject
{
    public int cost;
    public GameObject scriptPrefab;
}
