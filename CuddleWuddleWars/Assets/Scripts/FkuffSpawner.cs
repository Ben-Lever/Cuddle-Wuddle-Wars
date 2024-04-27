using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FkuffSpawner : MonoBehaviour
{
    public GameObject[] fluffPrefab;
    public float fluffInterval = 3.5f;
    public Transform[] spawnPoints;
   
    private Coroutine spawningCoroutine;
    private List<GameObject> spawnedFluff = new List<GameObject>(); // Corrected variable name

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        // Start the spawning coroutine and store the reference
        spawningCoroutine = StartCoroutine(SpawnFluff());
    }

    private IEnumerator SpawnFluff()
    {
        while (true)
        {
            //spawns
            /* int randomIndex = Random.Range(0, spawnPoints.Length);
             Vector3 spawnPosition = spawnPoints[randomIndex].position;
             GameObject fluff = Instantiate(fluffPrefab, spawnPosition, Quaternion.identity);
             spawnedFluff.Add(fluff); // Corrected variable name
             yield return new WaitForSeconds(fluffInterval); */

            // Iterate through each spawn point
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                // Select a random prefab from the array
                int randomPrefabIndex = Random.Range(0, fluffPrefab.Length);
                GameObject selectedPrefab = fluffPrefab[randomPrefabIndex];

                // Get the position of the current spawn point
                Vector3 spawnPosition = spawnPoints[i].position;

                // Instantiate the selected prefab at the spawn position
                GameObject fluff = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
                spawnedFluff.Add(fluff);

                float delay = fluffInterval * i;

                // Wait for the specified delay before spawning the next fluff prefab
                yield return new WaitForSeconds(delay);
            }

            // Wait for the specified interval before spawning again
            yield return new WaitForSeconds(fluffInterval);
        }
    }

    // Public method to adjust the fluff spawning interval
    public void AdjustFluffInterval(float newInterval)
    {
        fluffInterval = newInterval;

        // Stop the current spawning coroutine
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }

        // Start a new coroutine with the adjusted interval
        StartSpawning();
    }
}
