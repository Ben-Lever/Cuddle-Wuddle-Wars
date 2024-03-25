using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCardObjectScript : MonoBehaviour
{
    public GameObject SpriteRendChild;
    public GameObject TextChild;
    public Card cardInfo;
    public string cardWriting;

    public GameObject blankPrefab;

    public int Index { get; private set; }

    public GameObject plushPrefab; //place plush card here
    public int plushCost = 1;

    public Transform[] spawnPoints; // Array of spawn points
    // Start is called before the first frame update
    void Start()
    {
        if (cardInfo.isInitialised == false)
        {
            Debug.Log("Starting Card Initialisation");
            cardInfo.InitialiseCard();
            Debug.Log("Ending Card Initialisation");

            SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
            cardWriting = "LVL: " + cardInfo.level;
            TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        }
    }

    public void UpdateCardInfo()
    {
        cardWriting = "LVL: " + cardInfo.level;
        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        //CardManager.instance.TrueCurrentDeck();
    }

    public void OnButtonPress()
    {
        Debug.Log("Mouse clicked");
        CardManager.selectedCard = Index;
        Debug.Log("selectedCard = " + CardManager.selectedCard);
        //InventoryCanvas.GetComponent<Canvas>().enabled = true;


        ////////////////////////////////////////// Kelecia's Scripts
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
        
    }
    void SpawnPlush()
    {
        // Implement your logic to spawn a plush at a chosen spawn point
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject instance = Instantiate(plushPrefab, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
        instance.GetComponent<PlaceholderPlushScript>().PrefabStats(cardInfo);
    }
    // Update is called once per frame
    public void SetIndex(int index)
    {
        Index = index;
        Debug.Log("this object's indes: " + Index);
    }
}
