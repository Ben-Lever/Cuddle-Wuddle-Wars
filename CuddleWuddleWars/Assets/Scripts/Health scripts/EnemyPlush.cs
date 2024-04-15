using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlush : MonoBehaviour
{
    public int damageValue;

    public AudioClip hitSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerPlush"))
        {
            var healthComponent = collision.gameObject.GetComponent<PlushHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damageValue); //put amount of damage they will cause here

                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound); // Play the hit sound
                }
            }
        }

        if (collision.gameObject.CompareTag("playerStore"))
        {
            var healthComponent = collision.gameObject.GetComponent<StoreHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damageValue); //put amount of damage they deal here
            }
        }
    }
}
    
 