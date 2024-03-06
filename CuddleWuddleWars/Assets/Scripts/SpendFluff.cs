using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendFluff : MonoBehaviour
{  
    public GameObject plushPrefab; //place plush card here
    public int plushCost = 1;

    public Transform[] spawnPoints; // Array of spawn points

    public void OnButtonClick()
    {
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
        Instantiate(plushPrefab, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
    }

}
