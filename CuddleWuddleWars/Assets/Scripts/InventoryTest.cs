using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonParent;

    public GameObject InventoryCanvas;

    public bool isInventoryOpen;

    public void UpdateInventoryCardButtons(Card card)
    {
        GameObject newButton = Instantiate(buttonPrefab, buttonParent);
        newButton.GetComponent<InventoryButtons>().cardInfo = card;
        newButton.GetComponent<InventoryButtons>().obj = this.gameObject;

        card.associatedButton = newButton;

        // Set the button's text to the card's name and level
        TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.text = $"{card.cardName} Lvl {card.level}";
        }
    }

    public void CloseInventory()
    {
        if (isInventoryOpen == true)
        {
            InventoryCanvas.GetComponent<Canvas>().enabled = false;
            var list = CardManager.playerDeckList;
            foreach (var child in list)
            {
                child.GetComponent<BoxCollider2D>().enabled = true;
            }
            isInventoryOpen = false;
        }
        
    }

    private void Update()
    {
        if (InventoryCanvas.GetComponent<Canvas>().enabled == true)
        {
            isInventoryOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isInventoryOpen == true)
        {
            CloseInventory();
        }
    }

}
