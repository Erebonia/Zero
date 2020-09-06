using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damagePower = 1;
    
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    void OnTriggerStay2D(Collider2D player)
    {
        if (Time.time >= nextAttackTime)
        {
            player.GetComponent<Player>().TakeDamage(damagePower);
            nextAttackTime = Time.time + 1f / attackCooldown;
        }
        
    }
}
