using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardObjectScript : MonoBehaviour
{

    public GameObject SpriteRendChild;
    public GameObject TextChild;
    public Card cardInfo;
    public string cardWriting;

    public GameObject InventoryCanvas;

    public int Index { get; private set; }

    private void Start()
    {
        

        if (cardInfo.isInitialised == false)
        {
            Debug.Log("Starting Card Initialisation");
            cardInfo.InitialiseCard();
            Debug.Log("Ending Card Initialisation");
        }
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        cardWriting = 
            cardInfo.cardName + "\n" 
            + cardInfo.uniqueID + "\n"
            + "lvl " + cardInfo.level + " " + cardInfo.unitType + "\n"
            + "Attack: " + cardInfo.TotalAttack + "\n"
            + "Health: " + cardInfo.TotalHealth + "\n"
            + "Hit Speed: " + cardInfo.TotalHitSpeed;

        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
    }
    
    public void UpdateCardInfo()
    {
        Debug.Log(cardInfo.cardName);
        cardWriting =
           cardInfo.cardName + "\n"
           + cardInfo.uniqueID + "\n"
           + "lvl " + cardInfo.level + " " + cardInfo.unitType + "\n"
           + "Attack: " + cardInfo.TotalAttack + "\n"
           + "Health: " + cardInfo.TotalHealth + "\n"
           + "Hit Speed: " + cardInfo.TotalHitSpeed;
        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
    }

    public void LvlUp()
    {
        cardInfo.UpgradeCard();
        UpdateCardInfo();
    }

    private void Update()
    {
        if (cardInfo != null)
        {
            cardWriting =
           cardInfo.cardName + "\n"
           + cardInfo.uniqueID + "\n"
           + "lvl " + cardInfo.level + " " + cardInfo.unitType + "\n"
           + "Attack: " + cardInfo.TotalAttack + "\n"
           + "Health: " + cardInfo.TotalHealth + "\n"
           + "Hit Speed: " + cardInfo.TotalHitSpeed;
            TextChild.GetComponent<TextMeshPro>().text = cardWriting;
            SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        }
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse clicked");
        CardManager.selectedCard = Index;
        Debug.Log("selectedCard = " + CardManager.selectedCard);
        InventoryCanvas.GetComponent<Canvas>().enabled = true;
        var list = CardManager.playerDeckList;
        foreach (var child in list)
        {
            child.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void SetIndex(int index)
    {
        Index = index;
        Debug.Log("this object's indes: " + Index);
    }


}
