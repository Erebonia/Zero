using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    public int attackDamage = 1;

    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Switch state, conduct attack coroutine, and switch back to normal state.
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 0.5f / attackCooldown;
            }
        }

    }

    IEnumerator Attack()
    {
        //Set Attack State
        gameObject.GetComponent<Player>().state = Player.State.Attacking;

        //Play attack anim
        //animator.SetTrigger("attack 1");

        //Detect enemies in range of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemies.
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        yield return new WaitForSeconds(0.5f);

        //Reset State
        gameObject.GetComponent<Player>().state = Player.State.Normal;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    

}
