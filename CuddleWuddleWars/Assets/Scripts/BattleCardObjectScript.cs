using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCardObjectScript : MonoBehaviour
{
    public GameObject SpriteRendChild;
    public GameObject TextChild;
    public GameObject CostChild;
    public Card cardInfo;
    public string cardWriting;

    public GameObject blankPrefab;

    public int Index { get; private set; }

    public GameObject plushPrefab; //place plush card here
    public int plushCost;

    public Transform[] spawnPoints; // Array of spawn points

    public float spawnCooldown = 2f;
    private float cooldownTimer = 0f;
    private bool isCooldownActive = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = SpriteRendChild.GetComponent<SpriteRenderer>(); // Ensure SpriteRendChild is the correct GameObject
        originalColor = spriteRenderer.color;
        plushCost = cardInfo.cardCost;
        if (cardInfo.isInitialised == false)
        {
            Debug.Log("Starting Card Initialisation");
            cardInfo.InitialiseCard();
            Debug.Log("Ending Card Initialisation");

            SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
            cardWriting = "LVL: " + cardInfo.level;
            TextChild.GetComponent<TextMeshPro>().text = cardWriting;
            CostChild.GetComponent<TextMeshPro>().text = cardInfo.cardCost.ToString();
            Debug.Log(cardInfo.cardName + "costs " + cardInfo.cardCost);
        }
    }

    private void Update()
    {
        if (isCooldownActive)
        {
            cooldownTimer -= Time.deltaTime;

            float lerp = Mathf.Clamp01((spawnCooldown - cooldownTimer) / spawnCooldown);
            spriteRenderer.color = Color.Lerp(Color.grey, originalColor, lerp);

            if (cooldownTimer <= 0f)
            {
                isCooldownActive = false;
                spriteRenderer.color = originalColor;
                Debug.Log("Cooldown finished. You can spawn plushes again.");
            }
        }
    }
    public void UpdateCardInfo()
    {
        cardWriting = "LVL: " + cardInfo.level;
        TextChild.GetComponent<TextMeshPro>().text = cardWriting;
        SpriteRendChild.GetComponent<SpriteRenderer>().sprite = cardInfo.artwork;
        Debug.Log(cardInfo.cardName + " costs " + cardInfo.cardCost);
        CostChild.GetComponent<TextMeshProUGUI>().text = cardInfo.cardCost.ToString();//////////////////////////////////////////////
        plushCost = cardInfo.cardCost;
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
        if(!isCooldownActive)
        {
            // Implement your logic to spawn a plush at a chosen spawn point
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject instance = Instantiate(plushPrefab, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
            instance.GetComponent<PlaceholderPlushScript>().PrefabStats(cardInfo);
            
            spriteRenderer.color = new Color(0.10f, 0.10f, 0.10f, 1);

            isCooldownActive = true;
            cooldownTimer = spawnCooldown;
        }
        else
        {
            Debug.Log("Still on cooldown. Wait for it to finish.");
        }

    }
    // Update is called once per frame
    public void SetIndex(int index)
    {
        Index = index;
        Debug.Log("this object's indes: " + Index);
    }
}
