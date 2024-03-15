using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private List<CardData> deckData = new List<CardData>();

    public void SaveDeck(List<Card> deck)
    {
        deckData.Clear();

        foreach (var card in deck)
        {
            deckData.Add(new CardData(card)); // Assuming CardData has a constructor that accepts a Card object
        }

        // Correct the JsonUtility call with a proper wrapper usage
        Serialization<List<CardData>> wrapper = new Serialization<List<CardData>>(deckData);
        string json = JsonUtility.ToJson(wrapper);

        // Ensure you have the correct PlayerPrefs key and then save it
        PlayerPrefs.SetString("PlayerDeck", json);
        PlayerPrefs.Save();
    }

    public void LoadDeck()
    {
        string json = PlayerPrefs.GetString("PlayerDeck", string.Empty);
        if (!string.IsNullOrEmpty(json))
        {
            // Deserialize the JSON back into the wrapper object
            Serialization<List<CardData>> wrapper = JsonUtility.FromJson<Serialization<List<CardData>>>(json);
            List<CardData> loadedDeckData = wrapper.data;
            List<Card> loadedDeck = new List<Card>();

            foreach (var cardData in loadedDeckData)
            {
                // Assuming you have a method FindCardByUniqueID that retrieves the corresponding Card Scriptable Object
                ///////////
                
                /*
                Card card = CardManager.Instance.FindCardByUniqueID(cardData.uniqueID);
                if (card != null)
                {
                    // Apply the loaded data to the Card Scriptable Object
                    card.level = cardData.level;
                    card.attackIV = cardData.attackIV;
                    card.healthIV = cardData.healthIV;
                    card.hitSpeedIV = cardData.hitSpeedIV;
                    loadedDeck.Add(card);
                }
                */
                
            }

            // Now 'loadedDeck' contains all your cards with their saved stats
            // You can use this list to reconstruct the player's deck in the game
        }
    }

    // Dummy method for finding a Card by unique ID, replace with your actual implementation
    /*
    private Card FindCardByUniqueID(string uniqueID)
    {
        // Here you would search through your existing Scriptable Objects to find the one with the matching unique ID
        // Example:
        // return allCards.Find(card => card.uniqueID == uniqueID);
    }



    /*
    public Card[] startingDeck; // Assign this in the editor with your Card assets

    private void Start()
    {
        // Example of using a card method at the start
        foreach (var card in startingDeck)
        {
            // Assuming Card has a method like InitializeCard() or UpgradeCard()
            card.InitialiseCard();
            Debug.Log(card.cardName + " aquired");
            Debug.Log(card.unitType);
            Debug.Log("Attack: " + card.TotalAttack);
            Debug.Log("Health: " + card.TotalHealth);
            Debug.Log("HitSpeed: " + card.TotalHitSpeed);

            /*
            card.UpgradeCard();
            Debug.Log(card.cardName + " upgraded.");
            
        }
    }
    */
}
[System.Serializable]
public class Serialization<T>
{
    public T data;

    public Serialization(T data)
    {
        this.data = data;
    }
}
