using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinDisplay : MonoBehaviour
{
    public TextMeshProUGUI winText;

    // Method to update the win display text
    public void UpdateWinText()
    {
        // Retrieve the number of wins from PlayerPrefs
        int wins = PlayerPrefs.GetInt("Wins", 0);

        // Display the number of wins
        winText.text = wins.ToString();
    }
}
