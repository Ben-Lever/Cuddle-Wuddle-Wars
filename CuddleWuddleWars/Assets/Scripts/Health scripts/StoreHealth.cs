using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject gameOverCanvas;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {//anything you want to happen when they lose here
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            Debug.Log("this store lost");
        }
    }
}
