using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public int attackDamage = 1;

    public float attackCooldown = 0f;
    private float nextAttackTime = 0f;

    public int counter = 0;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                //Switch state, conduct attack coroutine, and switch back to normal state.
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 0.5f / attackCooldown;
            }
        }

    }

    IEnumerator Attack()
    {
        //Knockback Collider enable
        this.GetComponentInChildren<CircleCollider2D>().enabled = true;

        //Set Attack State
        gameObject.GetComponent<Player>().state = Player.State.Attacking;

        if (counter == 0)
        {
            //Play attack anim
            animator.SetTrigger("attacking");
            counter++;
        }else if (counter == 1)
        {
            animator.SetTrigger("attack_medium");
            counter++;
        }else if (counter == 2)
        {
            animator.SetTrigger("attack_heavy");
            counter = 0;
        }

        yield return new WaitForSeconds(0.29f);

        //Knockback Collider Disable after the attack is done
        this.GetComponentInChildren<CircleCollider2D>().enabled = false;

        //Reset State
        gameObject.GetComponent<Player>().state = Player.State.Normal;
    }

    

}
