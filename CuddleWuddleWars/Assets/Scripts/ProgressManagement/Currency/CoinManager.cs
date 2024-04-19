using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinsEarned = 10;
    public TextMeshProUGUI coinText;

    void Start()
    {
        // Add earned coins to the total coin count
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCoins += coinsEarned;
        PlayerPrefs.SetInt("Coins", currentCoins);
        PlayerPrefs.Save();

        coinText.text = currentCoins.ToString();
    }
}
