using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kas
/// This script is responsible for organizing all the other ability scripts
/// This is so the puchasing script does not get filled with to many unessecary scripts 
/// </summary>
/// 


public class AbilityManager : MonoBehaviour
{
    //public static AbilityManager instance;

    public TestItem testI; //test ability script 

    public Dictionary<AbilitySO, bool> abilityDictionary = new Dictionary<AbilitySO, bool>(); //dictionary to hold ability SOs and bool to see if its purchased or not

    public List<AbilitySO> abilitySOs; //holds a list of the ability SOs


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

    //when you start the run, this will active all the abilities bought (set to true)
    [ContextMenu("Apply Abilities")]
    public void ApplyAbilities()
    {
        List<AbilitySO> tempList = new List<AbilitySO>();
        //for each ability in the dictonary
        foreach (var ability in abilityDictionary)
        {
            //if the ability is purchased
            if(ability.Value == true)
            {
                //create the ability and use it 
                GameObject go = ability.Key.scriptPrefab;
                go.SetActive(true);
                go.GetComponent<IAbility>().UseAbility();
                //UpdateDictonary(ability.Key, false);
                tempList.Add(ability.Key); //add it to a temporary list list

                
            }
        }

        //for each purchased ability
        foreach (var ability in tempList)
        {
            //once they are done their job, set them back to false so the player can purchase it again on their next run
            UpdateDictonary(ability, false);
            Debug.Log("The " + ability.name + " is set to " + abilityDictionary[ability]);
        }
    }
}
