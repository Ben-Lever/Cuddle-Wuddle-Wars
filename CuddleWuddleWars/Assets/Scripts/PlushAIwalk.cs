using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushAIwalk : MonoBehaviour
{
    public GameObject enemyPlush;
    public float speed;

    private float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,enemyPlush.transform.position); //checking distance between plushes
        Vector2 direction = (enemyPlush.transform.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(this.transform.position, enemyPlush.transform.position, speed * Time.deltaTime); // moves player plush towards enemy

    }
}
