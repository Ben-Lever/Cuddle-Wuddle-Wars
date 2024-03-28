using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject gameOverCanvas;


    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    void Start()
    {
        currentHealth = maxHealth;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 2)
        {
            life3.SetActive(false);
        }
        else if (currentHealth <= 1)
        {
            life3.SetActive(false);
            life2.SetActive(false);
        }
        else if (currentHealth <= 0)
        {
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(false);
        }

        if (currentHealth < 0)
        {//anything you want to happen when they lose here
            //Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            Debug.Log("this store lost");
        }
    }
}
