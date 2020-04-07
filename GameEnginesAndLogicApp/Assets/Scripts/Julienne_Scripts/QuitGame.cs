using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void exitGame()
    {
        Debug.Log("Quiting the game.");
        Application.Quit();

    }
}
