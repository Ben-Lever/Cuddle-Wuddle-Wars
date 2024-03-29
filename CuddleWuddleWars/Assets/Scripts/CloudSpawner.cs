using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] cloudPrefabs; // Array of cloud prefabs
    public float cloudInterval = 4.5f;
    public Transform[] spawnPoints;
    public float cloudSpeed = 2f;

    private Coroutine spawningCoroutine;

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        // Start the spawning coroutine and store the reference
        spawningCoroutine = StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            int randomPrefabIndex = Random.Range(0, cloudPrefabs.Length); // Randomly select a cloud prefab
            GameObject selectedCloudPrefab = cloudPrefabs[randomPrefabIndex];

            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomSpawnPointIndex].position;
            GameObject cloud = Instantiate(selectedCloudPrefab, spawnPosition, Quaternion.identity);

            // Move the cloud continuously
            StartCoroutine(MoveCloud(cloud));

            yield return new WaitForSeconds(cloudInterval);
        }
    }

    private IEnumerator MoveCloud(GameObject cloud)
    {
        while (true)
        {
            // Move the cloud towards the right
            cloud.transform.Translate(Vector3.right * cloudSpeed * Time.deltaTime);

            // If the cloud moves out of the screen, destroy it
            if (cloud.transform.position.x > 20f) // Adjust the value as per your scene
            {
                Destroy(cloud);
                break;
            }

            yield return null;
        }
    }

    // Public method to adjust the cloud spawning interval
    public void AdjustCloudInterval(float newInterval)
    {
        cloudInterval = newInterval;

        // Stop the current spawning coroutine
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }

        // Start a new coroutine with the adjusted interval
        StartSpawning();
    }
}
