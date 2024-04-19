using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCardObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card cardInfo;
    public GameObject obj;
    public ToolTip toolTip;

    public GameObject CardNameObj;
    public GameObject CardLvlObj;
    public GameObject CardSprObj;

    public void SwapCard()
    {
        var toBeSwapped = CardManager.playerDeckList[CardManager.selectedCard];
        toBeSwapped.GetComponent<CardObjectScript>().cardInfo = cardInfo;
        toBeSwapped.GetComponent<CardObjectScript>().UpdateCardInfo();
        CardManager.Instance.SwapCardInDeck(CardManager.selectedCard, cardInfo);
        obj.GetComponent<InventoryReal>().CloseInventory();

    }

    public void UpdateInvCardObj()
    {


        CardNameObj.GetComponent<TextMeshProUGUI>().text = cardInfo.cardName;
        CardLvlObj.GetComponent<TextMeshProUGUI>().text = cardInfo.level.ToString();
        CardSprObj.GetComponent<Image>().sprite = cardInfo.artwork;
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
