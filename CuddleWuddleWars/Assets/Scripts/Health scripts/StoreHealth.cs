using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject gameOverCanvas;

    public AudioClip gameOverSound;
    private AudioSource audioSource;
    public AudioSource backgroundMusic; 
    public float backgroundMusicLowerVolume = 0.5f;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public int timesHit;

    void Start()
    {
        currentHealth = maxHealth;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);

        timesHit = 0;

        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (currentHealth <= 2)
        {
            life3.SetActive(false);
        }
        if (currentHealth <= 1)
        {
            life3.SetActive(false);
            life2.SetActive(false);
        }
        if (currentHealth <= 0)
        {
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(false);
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth--;
        //currentHealth -= amount;

        if (currentHealth <= 2)
        {
            life3.SetActive(false);
        }
        if (currentHealth <= 1)
        {
            life3.SetActive(false);
            life2.SetActive(false);
        }
        if (currentHealth <= 0)
        {
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(false);
        }

        if (currentHealth < 0)
        {
            //when this is not commented out the audio works fine but freezes game when it loads second time. 
         Time.timeScale = 0;

            if (backgroundMusic != null)
            {
                backgroundMusic.volume = backgroundMusicLowerVolume; // Lower the background music volume
            }

            if (audioSource != null && gameOverSound != null)
            {
                
                audioSource.Play();
            }

            gameOverCanvas.SetActive(true);
            Debug.Log("this store lost");
        }
    }
}
