using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControl : CharacterControl
{
    private Rigidbody2D playerRigidBody;
    private CharacterAnimation characterAnimation;

    private float slashDelay = 0.53f;

    Vector2 movement;

    void Start()
    {
        currentState = CharacterState.IDLE;
        playerRigidBody = GetComponent<Rigidbody2D>();
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input based on framerate
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        var isAttacking = IsAttacking();
        // This logic needs to change if we are not setting variables in the animator for stuff
        if (Input.GetButtonDown("slash") && !isAttacking)
        {
            StartCoroutine(SlashCo());
        }
        // Don't update animation if we are attacking, let it play out.
        else if (currentState <= CharacterState.WALK)
        {
            UpdateAnimation(isAttacking);
        }
    }

    void FixedUpdate()
    {
        // // Physics based on fixed update rate
        if (!IsAttacking())
        {
            playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void UpdateAnimation(bool isAttacking)
    {

        // Physics based on fixed update rate
        // if (!isAttacking)
        // {
        //     playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        // }
        // Set the animator movement for walking animations.
        // check if attak. NO MOVE
        // check if moving if (movement != Vector2.zero)
        // get direction
        // set lastDirection for idle

        lastDirection = CheckDirection(movement);

        if (isAttacking)
        {
            // todo: set animation for attak when I get animation set up

        }

        if (movement == Vector2.zero)
        {
            currentState = CharacterState.IDLE;
        }
        else
        {
            currentState = CharacterState.WALK;
        }

        characterAnimation.ChangeAnimationState(lastDirection, currentState);
    }

    private IEnumerator SlashCo()
    {
        lastDirection = CheckDirection(movement);
        currentState = CharacterState.SLASH;
        characterAnimation.ChangeAnimationState(lastDirection, currentState);
        // yield return null;
        yield return new WaitForSeconds(slashDelay);
        currentState = CharacterState.WALK;
    }

    // Update this if/when we add additional attack types.
    bool IsAttacking()
    {
        return currentState == CharacterState.SLASH;
    }

    CardinalDirection CheckDirection(Vector2 movement)
    {
        if (movement.x == 0 && movement.y == 1)
        {
            return CardinalDirection.NORTH;
        }
        else if (movement.x == -1 && movement.y == 0)
        {
            return CardinalDirection.WEST;
        }
        else if (movement.x == 0 && movement.y == -1)
        {
            return CardinalDirection.SOUTH;
        }
        else if (movement.x == 1 && movement.y == 0)
        {
            return CardinalDirection.EAST;
        }
        else
        {
            return lastDirection;
        }
    }
}
