using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for organizing all the other ability scripts
/// This is so the puchasing script does not get filled with to many unessecary scripts 
/// </summary>
/// 


public class AbilityManager : MonoBehaviour
{
    //public static AbilityManager instance;

    public TestItem testI; //test ability script 

    public Dictionary<AbilitySO, bool> abilityDictionary = new Dictionary<AbilitySO, bool>();

    public List<AbilitySO> abilitySOs;


    private void Awake()
    {
        #region Singleton Implementation (Disabled)
        /*
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }*/
        #endregion

        InitializeDictionary();
        
    }

    private void InitializeDictionary()
    {
        //for every ability SO added to the list of abilities
        for (int i = 0; i < abilitySOs.Count; i++)
        {
            AbilitySO variable = abilitySOs[i];

            //if it is not in the list, 
            if (!abilityDictionary.ContainsKey(variable))
            {
                //add it and make sure it is set to false (so it will not run)
                abilityDictionary.Add(variable, false);

                Debug.Log("The " + variable.name + " is set to " + abilityDictionary[variable]);
            }
        }
    }

    //updates the ability in the dictionary depending on if we need it on or off
    public void UpdateDictonary(AbilitySO ability, bool value)
    {
        abilityDictionary[ability] = value;
        
    }

   


    //reference from test script sent to here to use it in the purchasing script
    /*public void TestItemAbility()
    {
        testI.PlayCelebrationClip();
    }*/

    //when you start the run, this will active all the abilities bought (set to true)
    [ContextMenu("Apply Abilities")]
    public void ApplyAbilities()
    {
        List<AbilitySO> tempList = new List<AbilitySO>();

        foreach (var ability in abilityDictionary)
        {
            if(ability.Value == true)
            {
                GameObject go = Instantiate(ability.Key.scriptPrefab);
                go.GetComponent<IAbility>().UseAbility();
                //UpdateDictonary(ability.Key, false);
                tempList.Add(ability.Key);

                
            }
        }

        foreach (var ability in tempList)
        {
            UpdateDictonary(ability, false);
            Debug.Log("The " + ability.name + " is set to " + abilityDictionary[ability]);
        }
    }
}
