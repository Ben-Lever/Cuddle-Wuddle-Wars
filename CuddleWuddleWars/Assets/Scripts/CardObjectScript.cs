using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardObjectScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject SpriteRendChild;
    public GameObject TextChild;
    public Card cardInfo;
    public string cardWriting;

    public GameObject InventoryCanvas;

    public ToolTip toolTip;

    public GameObject BattleTabObject;

    /*////////////////////////////////////////// Kelecia's Scripts
    public GameObject plushPrefab; //place plush card here
    public int plushCost = 1;

    public Transform[] spawnPoints; // Array of spawn points
    */
    public int Index { get; private set; }

    private void Start()
    {
        //toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();

        if (cardInfo.isInitialised == false)
        {
            Debug.Log("Starting Card Initialisation");
            cardInfo.InitialiseCard();
            Debug.Log("Ending Card Initialisation");
        }
        /*/////// Commentted on sun 25/5
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        cardWriting = 
            cardInfo.cardName + "\n" 
            + cardInfo.uniqueID + "\n"
            + "lvl " + cardInfo.level + " " + cardInfo.unitType + "\n"
            + "Attack: " + cardInfo.TotalAttack + "\n"
            + "Health: " + cardInfo.TotalHealth + "\n"
            + "Hit Speed: " + cardInfo.TotalHitSpeed;

        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        */
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        cardWriting = "LVL: " + cardInfo.level;
        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        BattleTabObject.GetComponent<BattleMenuCard>().UpdateCardInfo();
    }
    
    public void UpdateCardInfo()
    {

        cardWriting = "LVL: " + cardInfo.level;
        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        BattleTabObject.GetComponent<BattleMenuCard>().UpdateCardInfo();
        //CardManager.instance.TrueCurrentDeck();
    }

    public void LvlUp()
    {
        cardInfo.UpgradeCard();
        UpdateCardInfo();
    }

    /*
    private void Update()/////// Commentted on sun 25/5
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
    */
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



        /*////////////////////////////////////////// Kelecia's Scripts
        //FluffCollector script attached to a GameObject in the scene
        FluffCollector fluffCollector = FindObjectOfType<FluffCollector>();

        if (fluffCollector != null && fluffCollector.fluffCount >= plushCost)
        {

            fluffCollector.fluffCount -= plushCost; // Deduct the cost from the player's fluff
            fluffCollector.UpdateFluffText(); // Update the fluff text after deducting the cost
            SpawnPlush();
            Debug.Log("plush spawned");
        }
        else
        {
            Debug.Log("Not enough fluff to spawn plush");
        }
        */
    }
    public void OnButtonPress()
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
        
        /*////////////////////////////////////////// Kelecia's Scripts
        //FluffCollector script attached to a GameObject in the scene
        FluffCollector fluffCollector = FindObjectOfType<FluffCollector>();

        if (fluffCollector != null && fluffCollector.fluffCount >= plushCost)
        {

            fluffCollector.fluffCount -= plushCost; // Deduct the cost from the player's fluff
            fluffCollector.UpdateFluffText(); // Update the fluff text after deducting the cost
            SpawnPlush();
            Debug.Log("plush spawned");
        }
        else
        {
            Debug.Log("Not enough fluff to spawn plush");
        }
        */
    }

    public void SetIndex(int index)
    {
        Index = index;
        Debug.Log("this object's indes: " + Index);
    }

    /*////////////////////////////////////////// Kelecia's Scripts
    void SpawnPlush()
    {
        // Implement your logic to spawn a plush at a chosen spawn point
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(plushPrefab, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
    }
    */

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Entered");
        if(this.cardInfo != null)
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
