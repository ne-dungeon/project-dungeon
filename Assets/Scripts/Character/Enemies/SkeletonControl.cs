using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonControl : EnemyControl
{
    // Start is called before the first frame update
    void Start()
    {
        SetStartVariables();
        TargetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState <= CharacterState.WALK)
        {
            UpdateAnimation();
        }
    }

    void FixedUpdate()
    {
        movement = Vector2.zero;
        ChasePlayer();
    }
}
