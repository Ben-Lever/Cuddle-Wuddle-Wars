using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryReal : MonoBehaviour
{
    public GameObject invCardPrefab;
    public Transform invCardParent;

    public GameObject InventoryCanvas;

    public bool isInventoryOpen;

    public ToolTip toolTip;
    public void CreateInvCardObj(Card card)
    {
        GameObject invCardObj = Instantiate(invCardPrefab, invCardParent);
        invCardObj.GetComponent<InventoryCardObject>().cardInfo = card;
        invCardObj.GetComponent<InventoryCardObject>().obj = this.gameObject;
        invCardObj.GetComponent<InventoryCardObject>().toolTip = toolTip;

        card.associatedButton = invCardObj;

        // Set the button's text to the card's name and level
        TextMeshProUGUI name = invCardObj.GetComponent<InventoryCardObject>().CardNameObj.GetComponent<TextMeshProUGUI>();
        if (name != null)
        {
            name.text = card.cardName;
        }
        TextMeshProUGUI lvl = invCardObj.GetComponent<InventoryCardObject>().CardLvlObj.GetComponent<TextMeshProUGUI>();
        if (lvl != null)
        {
            lvl.text = "Lvl: " + card.level.ToString();
        }
        Image spr = invCardObj.GetComponent<InventoryCardObject>().CardSprObj.GetComponent<Image>();
        if (spr != null)
        {
            spr.sprite = card.artwork;
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
