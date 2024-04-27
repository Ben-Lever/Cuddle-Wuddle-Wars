using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public void WatchAd()
    {
        Debug.Log("Watch the ad please");
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCoins += 50;
        PlayerPrefs.SetInt("Coins", currentCoins);
        SceneManager.LoadScene("AD");
    }
}
