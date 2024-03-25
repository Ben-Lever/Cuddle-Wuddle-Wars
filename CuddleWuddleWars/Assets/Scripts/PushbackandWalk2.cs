using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushbackandWalk2 : MonoBehaviour
{
    public GameObject store; // The store object to walk towards
    public string plushTag; // Tag plush it will be pushing off
    public string storeTag; //tag of store it will push off of
    public float speed;
    public float pushbackForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (store != null)
        {
            Vector2 direction = (store.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, store.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(plushTag))
        {
            // Calculate pushback direction
            Vector2 pushbackDirection = (transform.position - collision.transform.position).normalized;

            // Apply pushback force to the plush
            rb.AddForce(pushbackDirection * pushbackForce, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag(storeTag))
        {
            // Calculate pushback direction
            Vector2 pushbackDirection = (transform.position - collision.transform.position).normalized;

            // Apply pushback force to the plush
            rb.AddForce(pushbackDirection * pushbackForce, ForceMode2D.Impulse);
        }
    }
}

