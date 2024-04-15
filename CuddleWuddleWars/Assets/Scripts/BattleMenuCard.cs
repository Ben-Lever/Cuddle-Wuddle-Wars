using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleMenuCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject SpriteRendChild;
    public GameObject TextChild;
    public Card cardInfo;
    public string cardWriting;

    public GameObject InventoryCanvas;

    public ToolTip toolTip;

    public GameObject ShelfObject;

    private void Start()
    {
        cardInfo = ShelfObject.GetComponent<CardObjectScript>().cardInfo;
        UpdateCardInfo();
    }


    public void UpdateCardInfo()
    {
        cardInfo = ShelfObject.GetComponent<CardObjectScript>().cardInfo;
        cardWriting = "LVL: " + cardInfo.level;
        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
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
