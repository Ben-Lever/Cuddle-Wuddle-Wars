using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinDisplay : MonoBehaviour
{
    public TextMeshProUGUI winText;

    /* didnt work
    // Method to update the win display text
    public void UpdateWinText()
    {
        // Retrieve the number of wins from PlayerPrefs
        int wins = PlayerPrefs.GetInt("Wins", 0);

        // Display the number of wins
        winText.text = wins.ToString();
    }
    */

    void Start()
    {
        // Retrieve the coin count from PlayerPrefs
        int currentWins = PlayerPrefs.GetInt("Wins", 0);

        // Display the coin count in a UI Text element
        winText.text = currentWins.ToString();
    }
}
