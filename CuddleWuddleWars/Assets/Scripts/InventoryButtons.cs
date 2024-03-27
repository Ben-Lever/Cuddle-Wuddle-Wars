using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card cardInfo;
    public GameObject obj;
    public ToolTip toolTip;
    public void SwapCard()
    {
        var toBeSwapped = CardManager.playerDeckList[CardManager.selectedCard];
        toBeSwapped.GetComponent<CardObjectScript>().cardInfo = cardInfo;
        toBeSwapped.GetComponent<CardObjectScript>().UpdateCardInfo();
        CardManager.Instance.SwapCardInDeck(CardManager.selectedCard, cardInfo);
        obj.GetComponent<InventoryTest>().CloseInventory();

    }

    public void UpdateButton()
    {
        TextMeshProUGUI buttonText = this.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = $"{cardInfo.cardName} Lvl {cardInfo.level}";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Entered");
        if (this.cardInfo != null)
        {
            toolTip.GenerateToolTip(this.cardInfo);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exited");
        toolTip.gameObject.SetActive(false);
    }
}
