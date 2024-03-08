using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

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
            //ded, can play death anim here. 
            // anim.SetBool("isDead", trye);
            Debug.Log("your ded");
        }

    }
}
