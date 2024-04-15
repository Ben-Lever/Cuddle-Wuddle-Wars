using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;


    public GameObject fluffPrefab; // Reference to the fluff prefab 


    //public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth < 0)
        {
            //anything you want to happen when they die here
            DropFluff(); // Call the method to drop fluff
            Debug.Log("your ded");
            Destroy(this.gameObject);
        }

        void DropFluff()
        {
            // Instantiate the fluff prefab at the current position
            Instantiate(fluffPrefab, transform.position, Quaternion.identity);
        }
    }
}
