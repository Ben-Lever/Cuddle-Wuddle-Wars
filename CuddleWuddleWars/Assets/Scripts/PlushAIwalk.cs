using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushAIwalk : MonoBehaviour
{
    public GameObject otherPlush;
    public float speed;

    private float distance;

    public float pushbackForce;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        distance = Vector2.Distance(transform.position, otherPlush.transform.position); //checking distance between plushes
        Vector2 direction = (otherPlush.transform.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(this.transform.position, otherPlush.transform.position, speed * Time.deltaTime); // moves player plush towards enemy

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == otherPlush)
        {
            // Calculate pushback direction
            Vector2 pushbackDirection = (transform.position - otherPlush.transform.position).normalized;

            // Apply pushback force to both plushes
            rb.AddForce(pushbackDirection * pushbackForce, ForceMode2D.Impulse);

            Rigidbody2D otherRb = otherPlush.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                otherRb.AddForce(-pushbackDirection * pushbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
