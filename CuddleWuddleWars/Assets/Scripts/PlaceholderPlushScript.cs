using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

public class PlaceholderPlushScript : MonoBehaviour
{
    public void PrefabStats(Card card)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = card.artwork;//card sprite
        gameObject.GetComponent<PlushHealth>().maxHealth = card.TotalHealth;//card health
        gameObject.GetComponent<playerPlush>().damageValue = card.TotalAttack;//card attack stat
        gameObject.GetComponent<PushbackandWalk2>().speed = card.TotalHitSpeed;//card hitspeed

        Animator animator = gameObject.GetComponent<Animator>();
        if (animator != null && card.animatorController != null)
        {
            animator.runtimeAnimatorController = card.animatorController;
        }
    }
}
