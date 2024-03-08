using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlush : MonoBehaviour
{
  public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "playerPlush")
        {
            var healthComponent = collision.gameObject.GetComponent<PlushHealth>();
            if(healthComponent != null )
            {
                healthComponent.TakeDamage(1); //put amount of damage here
            }
        }
    }
}
