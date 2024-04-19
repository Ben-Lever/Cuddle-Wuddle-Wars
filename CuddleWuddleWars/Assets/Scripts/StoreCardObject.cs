using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreCardObject : MonoBehaviour
{
    public Card cardInfo;

    public GameObject TitleObject;
    public GameObject DescriptionObject;
    public GameObject CostObject;
    public GameObject ImageObject;
    // Start is called before the first frame update
    void Start()
    {
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
        ImageObject.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
    }
}
