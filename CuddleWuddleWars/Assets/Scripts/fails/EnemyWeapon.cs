using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject playerWeapon;
    public float pushbackForce;

    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Debug.Log("broken");
            Destroy(gameObject); // Destroy the weapon GameObject
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            var healthComponent = collision.gameObject.GetComponent<PlayerWeapon>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1); //put amount of damage here
            }
        }
    }

}
