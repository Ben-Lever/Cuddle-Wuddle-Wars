using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoreCardObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card cardInfo;

    public GameObject TitleObject;
    public GameObject DescriptionObject;
    public GameObject CostObject;
    public GameObject ImageObject;
    public ToolTip toolTip;
    public GameObject CoinManagerObj;
    // Start is called before the first frame update
    void Start()
    {
        //toolTip = GameObject.FindWithTag("ToolTip").GetComponent<ToolTip>();
        Card thisCard = CardManager.Instance.currentDeckTemplate[Random.Range(0, CardManager.Instance.currentDeckTemplate.Length)];
        Card newCardInstance = Instantiate(thisCard);
        if (newCardInstance.isInitialised == false)
        {
            newCardInstance.InitialiseCard();
        }
        cardInfo = newCardInstance;
        AssignStoreObjectStats();
    }

    public void AssignStoreObjectStats()
    {
        TitleObject.GetComponent<TextMeshProUGUI>().text = cardInfo.cardName;
        DescriptionObject.GetComponent<TextMeshProUGUI>().text = "";
        ImageObject.GetComponent<UnityEngine.UI.Image>().sprite = cardInfo.artwork;
    }

    public void PurchaseButtonPress()
    {
        //CardManager.Instance.AddCardsToTotalList(cardInfo);
        
        int coinTotal = PlayerPrefs.GetInt("Coins", 0);
        if (coinTotal >= 50)
        {
            CardManager.Instance.AddCardsToTotalList(cardInfo);
            Debug.Log("Spent 50 coins on" + cardInfo.cardName);
            coinTotal -= 50;
            PlayerPrefs.SetInt("Coins", coinTotal);
            //PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Not enough money");
        }
        
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
