using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        // Retrieve the coin count from PlayerPrefs
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);

        // Display the coin count in a UI Text element
        coinText.text = currentCoins.ToString();
    }
}
