using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControl : CharacterControl
{

    public CharacterState currentState;
    public float moveSpeed = 4f;

    private Rigidbody2D playerRigidBody;
    private CharacterAnimation characterAnimation;

    Vector2 movement;
    CardinalDirection lastDirection = CardinalDirection.SOUTH;


    void Start()
    {
        currentState = CharacterState.WALK;
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
            // Debug.Log(isAttacking());
            StartCoroutine(SlashCo());
        }
        else if (currentState == CharacterState.WALK)
        {
            UpdateAnimationAndMove(isAttacking);
        }
    }

    void FixedUpdate()
    {
        // // Physics based on fixed update rate
        // if (!IsAttacking())
        // {
        //     playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        // }
    }

    void UpdateAnimationAndMove(bool isAttacking)
    {

        // Physics based on fixed update rate
        if (!isAttacking)
        {
            playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        // Set the animator movement for walking animations.
        // check if attak. NO MOVE
        // check if moving if (movement != Vector2.zero)
        // get direction
        // set lastDirection for idle


        if (isAttacking)
        {
            // todo: set animation for attak when I get animation set up

        }

        // Set the animator last direction for idle animations.
        if (movement != Vector2.zero)
        {
            lastDirection = CheckDirection(movement);
            currentState = CharacterState.WALK;
        }

        characterAnimation.ChangeAnimationState(lastDirection, currentState);
    }

    private IEnumerator SlashCo()
    {
        // animator.SetBool("Slashing", true);
        currentState = CharacterState.SLASH;
        yield return null;
        // animator.SetBool("Slashing", false);
        yield return new WaitForSeconds(0.33f);
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
