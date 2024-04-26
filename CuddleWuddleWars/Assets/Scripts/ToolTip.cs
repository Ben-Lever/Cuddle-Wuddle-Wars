using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    private TextMeshProUGUI tooltipText;
    private GameObject tooltip;

    void Start()
    {
        tooltipText = GetComponentInChildren<TextMeshProUGUI>();
        tooltip = gameObject;
        tooltip.SetActive(false);
    }

    public void GenerateToolTip(Card card)
    {
        
        string statText = "";
        if (card.cardName != "BlankCard")
        {
            Debug.Log("Tooltip Triggered");
            statText += "Health: " + card.TotalHealth + "\n"
                + "Attack: " + card.TotalAttack + "\n"
                + "Hit Speed: " + card.TotalHitSpeed + "\n"
                + "Cost: " + card.cardCost;

            string toolTipString = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>", card.cardName, card.unitType, statText);
            tooltipText.text = toolTipString;
            tooltip.SetActive(true);
        }
    }
}
