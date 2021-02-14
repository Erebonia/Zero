using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{

    [SerializeField] private float thrust;
    [SerializeField] private float KnockBackDuration;
    public int attackDamage = 1;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemybody = other.GetComponent<Rigidbody2D>();
            bool hurt = other.GetComponent<EnemyFollow>().hurt = true;

            if (enemybody != null)
            {
                //Active Knockback Hitstate
                //enemybody.GetComponent<Player>().state = Player.State.Hurt;

                //Start Knocking them back
                StartCoroutine(KnockCoroutine(enemybody));

            }
        }
    }

    protected IEnumerator KnockCoroutine(Rigidbody2D enemybody)
    {

        Vector2 forceDirection = enemybody.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        enemybody.velocity = force;
        yield return new WaitForSeconds(KnockBackDuration);

        enemybody.velocity = new Vector2();

        //Deactivate Knockback hitstate
        //enemybody.GetComponent<Player>().state = Player.State.Normal;
        enemybody.GetComponent<EnemyFollow>().hurt = false;

        enemybody.GetComponent<Enemy>().TakeDamage(attackDamage);
    }
}
