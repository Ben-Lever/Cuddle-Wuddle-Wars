using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlush : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemyPlush"))
        {
            var healthComponent = collision.gameObject.GetComponent<PlushHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1); //put amount of damage they deal here
            }
        }

        if (collision.gameObject.CompareTag("enemyStore"))
        {
            var healthComponent = collision.gameObject.GetComponent<StoreHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1); //put amount of damage they deal here
            }
        }
    }
}
