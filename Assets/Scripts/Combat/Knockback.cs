using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] protected float thrust;
    [SerializeField] protected float KnockBackDuration;

    protected void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D enemybody = other.GetComponent<Rigidbody2D>();
            if (enemybody != null)
            {
                //Active Knockback Hitstate
                enemybody.GetComponent<Player>().state = Player.State.Hurt;

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
        enemybody.GetComponent<Player>().state = Player.State.Normal;
    }
}