using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardManager : MonoBehaviour
{
    public Card currentCard; // Assign this in the Inspector with your base card template

    // A path to save your card data
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "card.json");
    }

    public void SaveCard()
    {
        string json = JsonUtility.ToJson(currentCard);
        File.WriteAllText(savePath, json);
        Debug.Log("Card saved to " + savePath);
    }

    public void LoadCard()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, currentCard);
            Debug.Log("Card loaded from " + savePath);
        }
        else
        {
            Debug.LogError("Save file not found.");
        }
    }
    /*
    public static CardManager Instance { get; private set; }
    // A Dictionary to hold all cards with their unique ID as the key
    private Dictionary<string, Card> cardDictionary = new Dictionary<string, Card>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeCardDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeCardDictionary()
    {
        var allCards = Resources.LoadAll<Card>("PathToYourCards");

        foreach (var card in allCards)
        {
            if (!cardDictionary.ContainsKey(card.uniqueID))
            {
                cardDictionary.Add(card.uniqueID, card);
            }
            else
            {
                Debug.LogWarning("Duplicate card ID detected: " + card.uniqueID);
            }
        }
    }

    public Card FindCardByUniqueID(string uniqueID)
    {
        if (cardDictionary.TryGetValue(uniqueID, out Card card))
        {
            return card;
        }
        else
        {
            Debug.LogError("Card not found with ID: " + uniqueID);
            return null;
        }
    }
    */
}
