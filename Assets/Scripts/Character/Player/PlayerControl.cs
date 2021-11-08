using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControl : CharacterControl
{
    // Update method for Player depends on input, so can't be generalized.
    void Update()
    {
        // Input based on framerate
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        isAttacking = IsAttacking();

        if (Input.GetButtonDown("slash") && !isAttacking)
        {
            StartCoroutine(PlaySlash());
        }
        // Don't update animation if we are attacking, let it play out.
        else if (currentState <= CharacterState.WALK)
        {
            UpdateAnimation();
        }
    }
}
