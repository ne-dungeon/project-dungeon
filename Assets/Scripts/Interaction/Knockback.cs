using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collisionObject.GetComponent<Rigidbody2D>();
            // CharacterControl enemyControl = collisionObject.GetComponent<CharacterControl>();
            if (enemy != null)
            {
                StartCoroutine(PlayKnockBack(enemy));
                // Add code with enemyControl to start the knockback animation here. probably pass knocktime as variable.
            }
        }
    }

    private IEnumerator PlayKnockBack(Rigidbody2D enemy)
    {
        var enemyControl = enemy.GetComponent<CharacterControl>();
        enemyControl.currentState = CharacterControl.CharacterState.STAGGER;
        Vector2 difference = enemy.transform.position - transform.position;
        Vector2 force = difference.normalized * thrust;
        enemy.velocity = force;
        yield return new WaitForSeconds(knockTime);
        enemy.velocity = Vector2.zero;
        enemyControl.currentState = CharacterControl.CharacterState.IDLE;
    }
}
