using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlush : MonoBehaviour
{
    public int damageValue = 1;

    public AudioClip hitSound;
    private AudioSource audioSource;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemyPlush"))
        {
            var healthComponent = collision.gameObject.GetComponent<PlushHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damageValue); //put amount of damage they deal here

                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound); // Play the hit sound
                }
            }
        }

        if (collision.gameObject.CompareTag("enemyStore"))
        {
            var healthComponent = collision.gameObject.GetComponent<StoreHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damageValue); //put amount of damage they deal here
            }
        }
    }
}
