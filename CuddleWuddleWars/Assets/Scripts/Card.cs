using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Tank, 
    Support,
    Damage,
    Blank
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
[System.Serializable]
public class Card : ScriptableObject
{
    public string cardName;
    public string uniqueID;
    public Sprite artwork;
    public UnitType unitType;
    public int baseAttack;
    public int baseHealth;
    public float baseHitSpeed;
    public int attackIV; // Additional stat points for attack
    public int healthIV; // Additional stat points for health
    public float hitSpeedIV; // Additional stat points for hit speed
    public int level;

    public bool isInitialised = false;

    // Constructor to initialize a card with its base stats and random IVs
    public void InitialiseCard()
    {
        
        //Card newCard = ScriptableObject.CreateInstance<Card>();
        //newCard.uniqueID = System.Guid.NewGuid().ToString();
        uniqueID = System.Guid.NewGuid().ToString();

        AssignBaseStats();
        GenerateRandomIVs();
        isInitialised = true;
        
    }

    void AssignBaseStats()
    {
        // Temp base stats distribution
        switch (unitType)
        {
            case UnitType.Tank:
                baseAttack = 5;
                baseHealth = 100;
                baseHitSpeed = 1.5f;
                break;
            case UnitType.Support:
                baseAttack = 3;
                baseHealth = 60;
                baseHitSpeed = 1.0f;
                break;
            case UnitType.Damage:
                baseAttack = 10;
                baseHealth = 40;
                baseHitSpeed = 0.5f;
                break;
            case UnitType.Blank:
                baseAttack = 0;
                baseHealth = 0;
                baseHitSpeed = 0;
                break;
        }
        if (level == 0)
        {
            level = 1;
        }
    }

    void GenerateRandomIVs()
    {
        // Generate random additional stat points
        attackIV = Random.Range(0, 5); // Temp range
        healthIV = Random.Range(0, 10); // Temp range
        hitSpeedIV = Random.Range(0f, 0.5f); // Temp range
    }

    // Method to calculate total stats, including IVs
    public int TotalAttack => baseAttack + attackIV;
    public int TotalHealth => baseHealth + healthIV;
    public float TotalHitSpeed => baseHitSpeed + hitSpeedIV;

    // Method to upgrade card, potentially enhancing IVs or base stats
    public void UpgradeCard()
    {
        level++;
        baseAttack += baseAttack + (level - 1) * 2;
        baseHealth += baseHealth + (level - 1) * 2;
        baseHitSpeed += baseHitSpeed + (level - 1) * 2;
        // Optional: Adjust IVs or base stats based on level
    }


    public void CopyCard(Card other)
    {
        cardName = other.cardName;
        uniqueID = other.uniqueID;
        artwork = other.artwork;
        unitType = other.unitType;
        baseAttack = other.baseAttack;
        baseHealth = other.baseHealth;
        baseHitSpeed = other.baseHitSpeed;
        attackIV = other.attackIV;
        healthIV = other.healthIV;
        level = other.level;
    }
}

[System.Serializable]
public class CardData
{
    public string cardName;
    public string uniqueID;
    public Sprite artwork;
    public UnitType unitType;
    public int baseAttack;
    public int baseHealth;
    public float baseHitSpeed;
    public int attackIV; // Additional stat points for attack
    public int healthIV; // Additional stat points for health
    public float hitSpeedIV; // Additional stat points for hit speed
    public int level;

    public CardData(Card card)
    {
        cardName = card.cardName;
        uniqueID = card.uniqueID;
        artwork = card.artwork;
        unitType = card.unitType;
        baseAttack = card.baseAttack;
        baseHealth = card.baseHealth;
        baseHitSpeed = card.baseHitSpeed;
        attackIV = card.attackIV;
        healthIV = card.healthIV;
        hitSpeedIV = card.hitSpeedIV;
        level = card.level;
    }

}