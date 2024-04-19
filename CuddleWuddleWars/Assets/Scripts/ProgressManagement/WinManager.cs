using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    /*
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
    */

    //just copied coins
    public int winsEarned = 1;
    public TextMeshProUGUI winText;

    void Start()
    {
        // Add earned coins to the total coin count
        int currentWins = PlayerPrefs.GetInt("Wins", 0);
        currentWins += winsEarned;
        PlayerPrefs.SetInt("Wins", currentWins);
        PlayerPrefs.Save();

        winText.text = currentWins.ToString();
    }
}
