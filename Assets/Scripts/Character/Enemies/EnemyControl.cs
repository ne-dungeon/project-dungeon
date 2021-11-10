using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : NPCControl
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    public bool hostile = true;

    protected void TargetPlayer()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    protected void ChasePlayer()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            var newPosition = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            var change = new Vector2((newPosition.x - transform.position.x), (newPosition.y - transform.position.y));
            // If we actually moved, set the movement value for changing animations.
            if (change != Vector2.zero)
            {
                // If our change in x is greater than our change in y, use x; otherwise, use y.
                if (Math.Abs(change.x) > Math.Abs(change.y))
                {
                    if (change.x > 0)
                    {
                        movement = Vector2.right;
                    }
                    else
                    {
                        movement = Vector2.left;
                    }
                }
                else
                {
                    if (change.y > 0)
                    {
                        movement = Vector2.up;
                    }
                    else
                    {
                        movement = Vector2.down;
                    }
                }
            }
            transform.position = newPosition;
            // Using this makes the enemy SUPER SLOW D: hopefully next videos will provide insight on fixing this.
            // characterRigidBody.MovePosition(newPosition);
        }
    }

    protected void Patrol(int steps)
    {
        // if not too close to player, pick a direction, walk x steps, stop for y seconds, pick another direction
        // how to check for encountering wall?
        // coroutine?
        // if hostile will switch to chase player,if not, will ignore player proximity until player talks to them
        // Use state interact to pause movement for talking?
        // Set edges to patrol area for creatures not in rooms?
    }
}
