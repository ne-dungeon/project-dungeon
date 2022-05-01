using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControl : CharacterControl
{
    // Update method for Player depends on input, so can't be generalized.
    void Update()
    {
        // Input based on framerate
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Setting variable here rather than just using the function call prevents a
        // movement bug associated with trying to move and attacking at the same time.
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

    void FixedUpdate()
    {
        // Physics based on fixed update rate
        if (!isAttacking)
        {
            characterRigidBody.MovePosition(characterRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
