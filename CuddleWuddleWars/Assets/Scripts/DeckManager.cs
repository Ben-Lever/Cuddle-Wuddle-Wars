using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
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
            */
        }
    }
}
