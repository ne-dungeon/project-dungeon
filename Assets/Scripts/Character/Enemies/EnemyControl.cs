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
        }
    }
}
