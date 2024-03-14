using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject enemyWeapon;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            var healthComponent = collision.gameObject.GetComponent<EnemyWeapon>(); //get health from this script
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1); //put amount of damage here
            }
        }
    }
}

