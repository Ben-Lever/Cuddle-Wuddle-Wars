using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Tank, 
    Support,
    Damage
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public UnitType unitType;
    private int baseAttack;
    private int baseHealth;
    private float baseHitSpeed;
    private int attackIV; // Additional stat points for attack
    private int healthIV; // Additional stat points for health
    private float hitSpeedIV; // Additional stat points for hit speed
    public int level;

    // Constructor to initialize a card with its base stats and random IVs
    public void InitializeCard(UnitType type)
    {
        unitType = type;
        AssignBaseStats();
        GenerateRandomIVs();
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
        // Optional: Adjust IVs or base stats based on level
    }
}
