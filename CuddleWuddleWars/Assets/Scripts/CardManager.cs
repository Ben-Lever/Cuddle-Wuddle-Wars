using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    // A path to save your card data
    private string savePath;
    public Card[] currentDeckTemplate;
    public List<Card> currentDeck; 
    public GameObject PlayerDeck;
    public static List<GameObject> playerDeckList = new List<GameObject>();
    public CardObjectScript cardObjectScript;
    public static List<Card> TotalCardList = new List<Card>();
    public GameObject InventoryUIManager;
    public static int selectedCard;

    public static List<Card> TrueCurrentDeck;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().name != "battlescene")////////////////////////////////////////////////////
        {
            StartCardManager();
        }
       
    }
    public void StartCardManager()
    {
        Debug.Log("Starting CardManager");
        savePath = Path.Combine(Application.persistentDataPath, "deck.json");
        InstantiateDeck();

        if (PlayerDeck != null)
        {
            // Clear the list to make sure it's empty before adding new items.
            playerDeckList.Clear();

            foreach (Transform child in PlayerDeck.transform)
            {
                playerDeckList.Add(child.gameObject);

                // You should only get the component once per child.
                var script = child.GetComponent<CardObjectScript>();
                script.SetIndex(playerDeckList.Count - 1);
                if (script != null && playerDeckList.Count <= currentDeck.Count)
                {
                    // Since playerDeckList has just been added to, its count reflects the next index.

                    script.cardInfo = currentDeck[playerDeckList.Count - 1];

                }
            }

            // Ensure the TotalCardList is updated only after all operations above.
            TotalCardList.Clear(); // Clear it first to avoid duplicates if Awake() runs multiple times for any reason.
            foreach (var card in currentDeck)
            {
                TotalCardList.Add(card);
                InventoryUIManager.GetComponent<InventoryTest>().UpdateInventoryCardButtons(card);
            }
        }
        if (PlayerDeck != null)
        {
            //int i = 0;
            foreach (Transform child in PlayerDeck.transform)
            {
                playerDeckList.Add(child.gameObject);
                Debug.Log("PlayerDeckList" + child.gameObject.name);
                //cardObjectScript = child.GetComponent<CardObjectScript>();//////////////////////////////Commented 27/03
                /*if (cardObjectScript != null)
                {
                    
                    cardObjectScript = child.gameObject.GetComponent<CardObjectScript>();
                    //cardObjectScript.cardInfo = currentDeck[i];
                    i++;
                }*/
            }
            foreach (var CARD in currentDeck)
            {
                TotalCardList.Add(CARD);
            }
        }
        DeckManager();
        StarterDeck();
    }

    public void InstantiateDeck()
    {
        currentDeck.Clear();

        foreach (var cardTemplate in currentDeckTemplate)
        {
            if (cardTemplate.unitType != UnitType.Blank)
            {
                Debug.Log("Im being triggered");
                Card newCardInstance = ScriptableObject.CreateInstance<Card>();
                newCardInstance.CopyCard(cardTemplate);
                //currentDeck.Add(newCardInstance);
            }

        }
    }

    public void SaveCard()
    {
        List<CardData> deckData = new List<CardData>();
        foreach (var card in TotalCardList) /////////////////////USED TO BE CURRENTDECK
        {
            CardData data = new CardData(card);
            deckData.Add(data);
        }

        // Convert the list to a JSON string
        string json = JsonUtility.ToJson(new Serialization<List<CardData>>(deckData), true);
        File.WriteAllText(savePath, json);
        Debug.Log("Deck saved to " + savePath);
        /*
        string json = JsonUtility.ToJson(currentCard);
        File.WriteAllText(savePath, json);
        Debug.Log("Card saved to " + savePath);
        */
    }

    public void LoadCard()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            Serialization<List<CardData>> deckData = JsonUtility.FromJson<Serialization<List<CardData>>>(json);

            TotalCardList.Clear(); // Clear the list

            foreach (var cardData in deckData.data)
            {
                Card newCardInstance = ScriptableObject.CreateInstance<Card>();
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(cardData), newCardInstance);
                TotalCardList.Add(newCardInstance);
                // You might need to update any UI or game elements that depend on TotalCardList here
            }

            Debug.Log("Deck loaded from " + savePath);
            foreach (Card card in TotalCardList)
            {
                Debug.Log(card.cardName);
            }
            DeckManager();
        }
        else
        {
            Debug.LogError("Save file not found.");
        }
        /*
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            // Deserialize the JSON back to the list of card data objects
            Serialization<List<CardData>> deckData = JsonUtility.FromJson<Serialization<List<CardData>>>(json);

            //InstantiateDeck();

            for (int i = 0; i < TotalCardList.Count; i++)
            {
                // Assuming the deck is already populated with the correct number of cards, overwrite their data
                JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(deckData.data[i]), TotalCardList[i]);

                int index = playerDeckList.Count - 1;
                if (index < TotalCardList.Count)
                {
                    //cardObjectScript.cardInfo = (TotalCardList[index]);
                }
                else
                {
                    Debug.LogWarning("Insufficient savedScriptableObjects for all children.");
                }
            }
            Debug.Log("Deck loaded from " + savePath);
        }
        else
        {
            Debug.LogError("Save file not found.");
        }
        */
    }

    public void LevelUpCards()
    {
        foreach (Transform child in PlayerDeck.transform)
        {
            child.GetComponent<CardObjectScript>().LvlUp();
        }   
    }

    public void GenerateRandomCard()
    {
        int randomIndex = Random.Range(0, currentDeckTemplate.Length);
        Card selectedTemplate = currentDeckTemplate[randomIndex];

        Card newCardInstance = Instantiate(selectedTemplate);
        if (newCardInstance.isInitialised == false)
        {
            newCardInstance.InitialiseCard();
        }
        TotalCardList.Add(newCardInstance);
        InventoryUIManager.GetComponent<InventoryTest>().UpdateInventoryCardButtons(newCardInstance);
        //UpdateDeckVisuals();
        DeckManager();
    }

    public void StarterDeck()
    {
        //loops the second loop 3 times, resulting in twelve cards in the order of 1,2,3,4,1,2,3,4,1,2,3,4
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                Card selectedTemplate = currentDeckTemplate[i];
                Card newCardInstance = Instantiate(selectedTemplate);
                if (newCardInstance.isInitialised == false)
                {
                    newCardInstance.InitialiseCard();
                }
                TotalCardList.Add(newCardInstance);
                InventoryUIManager.GetComponent<InventoryTest>().UpdateInventoryCardButtons(newCardInstance);
                DeckManager();
                Debug.Log(newCardInstance.cardName + "was instantiated");
            }
        }
        
    }
    public void DeckManager()
    {
        // Ensure the deck has less than 4 cards and attempt to fill it up
        while (currentDeck.Count < 4 && TotalCardList.Count > currentDeck.Count)
        {
            foreach (var potentialCardToAdd in TotalCardList)
            {
                if (!currentDeck.Contains(potentialCardToAdd))
                {
                    currentDeck.Add(potentialCardToAdd);

                    // Update the GameObjects representing cards in the player's deck.
                    UpdateCardGameObjects();

                    // Break since we've successfully added a card.
                    break;
                }
            }
        }
        /*
        //Is there room in the Deck?
        if (currentDeck.Count > 4)
        {
            for (int i = currentDeck.Count; i < 4; i++ )
            {
                if (currentDeck[i] != TotalCardList[i])
                {
                    currentDeck.Add(TotalCardList[i]);
                }
                else
                {
                    
                }

            }
        }
        */
    }
    private void UpdateCardGameObjects()
    {
        // Make sure not to exceed bounds of either list
        int count = Mathf.Min(playerDeckList.Count, currentDeck.Count);

        for (int i = 0; i < count; i++)
        {
            var script = playerDeckList[i].GetComponent<CardObjectScript>();
            if (script != null)
            {
                script.cardInfo = currentDeck[i];
                script.UpdateCardInfo();
            }
        }
        //UpdateTrueCurrentDeck();/////////////////////////////////////////////////////////////
    }

    private void UpdateDeckVisuals()
    {
        for (int i = 0; i < playerDeckList.Count; i++)
        {
            if (i < currentDeck.Count)
            {
                var cardScript = playerDeckList[i].GetComponent<CardObjectScript>();
                if (cardScript != null)
                {
                    cardScript.cardInfo = currentDeck[i];
                }
            }
            else
            {
                // Optionally handle the case where there are more slots than cards.
                // For example, disable the extra GameObjects.
                //playerDeckList[i].SetActive(false);////////////////////////////////////
            }
        }
        //UpdateTrueCurrentDeck();/////////////////////////////////////////////////////////////////
    }

    public void SwapCardInDeck(int cardIndexToSwap, Card newCard)
    {
        if (cardIndexToSwap < currentDeck.Count)
        {
            currentDeck[cardIndexToSwap] = newCard;
            
        }

    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "battlescene")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //bool test = false;
            if (!PlayerDeck)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //test= true;
                
                PlayerDeck = GameObject.FindWithTag("PlayerDeck");
                InventoryUIManager = GameObject.FindWithTag("InventoryUIManager");
                //StartCardManager();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //Debug.Log("Starting CardManager");
                savePath = Path.Combine(Application.persistentDataPath, "deck.json");
                //InstantiateDeck();

                if (PlayerDeck != null)
                {
                    // Clear the list to make sure it's empty before adding new items.
                    playerDeckList.Clear();

                    foreach (Transform child in PlayerDeck.transform)
                    {
                        playerDeckList.Add(child.gameObject);

                        // You should only get the component once per child.
                        var script = child.GetComponent<CardObjectScript>();
                        script.SetIndex(playerDeckList.Count - 1);
                        if (script != null && playerDeckList.Count <= currentDeck.Count)
                        {
                            // Since playerDeckList has just been added to, its count reflects the next index.

                            script.cardInfo = currentDeck[playerDeckList.Count - 1];

                        }
                    }

                    // Ensure the TotalCardList is updated only after all operations above.
                    /*
                    TotalCardList.Clear(); // Clear it first to avoid duplicates if Awake() runs multiple times for any reason.
                    foreach (var card in currentDeck)
                    {
                        TotalCardList.Add(card);
                        InventoryUIManager.GetComponent<InventoryTest>().UpdateInventoryCardButtons(card);
                    }
                    */
                }
                if (PlayerDeck != null)
                {
                    //int i = 0;
                    foreach (Transform child in PlayerDeck.transform)
                    {
                        playerDeckList.Add(child.gameObject);
                        Debug.Log("PlayerDeckList" + child.gameObject.name);
                        //cardObjectScript = child.GetComponent<CardObjectScript>();//////////////////////////////Commented 27/03
                        /*if (cardObjectScript != null)
                        {

                            cardObjectScript = child.gameObject.GetComponent<CardObjectScript>();
                            //cardObjectScript.cardInfo = currentDeck[i];
                            i++;
                        }*/
                    }
                    /*
                    foreach (var CARD in currentDeck)
                    {
                        TotalCardList.Add(CARD);
                    }
                    */
                }
                DeckManager();
                //StarterDeck();
            }
            
        }
    }
    

















    /*
    public static CardManager Instance { get; private set; }
    // A Dictionary to hold all cards with their unique ID as the key
    private Dictionary<string, Card> cardDictionary = new Dictionary<string, Card>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeCardDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeCardDictionary()
    {
        var allCards = Resources.LoadAll<Card>("PathToYourCards");

        foreach (var card in allCards)
        {
            if (!cardDictionary.ContainsKey(card.uniqueID))
            {
                cardDictionary.Add(card.uniqueID, card);
            }
            else
            {
                Debug.LogWarning("Duplicate card ID detected: " + card.uniqueID);
            }
        }
    }

    public Card FindCardByUniqueID(string uniqueID)
    {
        if (cardDictionary.TryGetValue(uniqueID, out Card card))
        {
            return card;
        }
        else
        {
            Debug.LogError("Card not found with ID: " + uniqueID);
            return null;
        }
    }
    */
}
