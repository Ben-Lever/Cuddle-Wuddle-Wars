using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{

    private bool gameWon = false; // Track if the game has been won

    // Method to set the game as won
    public void SetGameWon()
    {
        gameWon = true;

        // Increment the number of wins
        int wins = PlayerPrefs.GetInt("Wins", 0);
        wins++;
        PlayerPrefs.SetInt("Wins", wins);
        PlayerPrefs.Save();
    }

    // Method to check if the game has been won
    public bool IsGameWon()
    {
        return gameWon;
    }
}
