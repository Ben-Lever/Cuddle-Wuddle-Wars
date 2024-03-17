using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
    public Card cardInfo;
    public GameObject obj;
    public void SwapCard()
    {
        var toBeSwapped = CardManager.playerDeckList[CardManager.selectedCard];
        toBeSwapped.GetComponent<CardObjectScript>().cardInfo = cardInfo;
        obj.GetComponent<InventoryTest>().CloseInventory();

    }

}
