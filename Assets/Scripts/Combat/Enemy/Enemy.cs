using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Animator anim;

    public int maxHitpoints = 10;
    private int hitpoints = 10;

    void Start()
    {
        hitpoints = maxHitpoints;
    }

    public void TakeDamage(int damage)
    {
        hitpoints -= damage;

        //Play hurt animation
        // anim.SetTrigger("Hurt");

        if (hitpoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("I am dead");
        gameObject.SetActive(false);
        // anim.SetBool("Dead", true);
    }
}
