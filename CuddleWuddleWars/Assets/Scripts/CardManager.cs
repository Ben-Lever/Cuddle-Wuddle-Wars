using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;

public class CardManager : MonoBehaviour
{
    public Card currentCard; // Assign this in the Inspector with your base card template

    // A path to save your card data
    private string savePath;
    public List<Card> currentDeck; // This will hold your deck of cards
    public GameObject PlayerDeck;
    public List<GameObject> playerDeckList = new List<GameObject>();
    public CardObjectScript cardObjectScript;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "deck.json");

        if (PlayerDeck != null )
        {
            foreach (Transform child in PlayerDeck.transform)
            {
                playerDeckList.Add(child.gameObject);

                cardObjectScript = child.GetComponent<CardObjectScript>();
                if (cardObjectScript != null)
                {
                    cardObjectScript = child.gameObject.GetComponent<CardObjectScript>();
                }
            }
        }
    }


    public void SaveCard()
    {
        List<CardData> deckData = new List<CardData>();
        foreach (var card in currentDeck)
        {
            CardData data = new CardData(card);
            deckData.Add(data);
        }

        // Convert the list to a JSON string
        string json = JsonUtility.ToJson(new Serialization<List<CardData>>(deckData), true);
        File.WriteAllText(savePath, json);
        Debug.Log("Deck saved to " + savePath);


        /*
        string json = JsonUtility.ToJson(currentCard);
        File.WriteAllText(savePath, json);
        Debug.Log("Card saved to " + savePath);
        */
        
    }

    public void LoadCard()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            // Deserialize the JSON back to the list of card data objects
            Serialization<List<CardData>> deckData = JsonUtility.FromJson<Serialization<List<CardData>>>(json);

            for (int i = 0; i < currentDeck.Count; i++)
            {
                // Assuming the deck is already populated with the correct number of cards, overwrite their data
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(deckData.data[i]), currentDeck[i]);

                int index = playerDeckList.Count - 1;
                if (index < currentDeck.Count)
                {
                    cardObjectScript.cardInfo = (currentDeck[index]);
                }
                else
                {
                    Debug.LogWarning("Insufficient savedScriptableObjects for all children.");
                }
            }

            Debug.Log("Deck loaded from " + savePath);
        }
        else
        {
            Debug.LogError("Save file not found.");
        }

        

        /*
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
        */
    }

    public void LevelUpCards()
    {
        foreach (Transform child in PlayerDeck.transform)
        {
            child.GetComponent<CardObjectScript>().LvlUp();
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
