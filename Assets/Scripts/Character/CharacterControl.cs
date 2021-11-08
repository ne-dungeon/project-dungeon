using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public enum CharacterState
    {
        IDLE,
        INTERACT,
        WALK,
        SLASH
    }

    // Control variables
    public CharacterState currentState;
    public CardinalDirection lastDirection = CardinalDirection.SOUTH;

    protected Rigidbody2D characterRigidBody;
    protected CharacterAnimation characterAnimation;

    protected Vector2 movement;
    protected bool isAttacking = false;

    // Variables that can change based on entity
    public float moveSpeed = 3f;
    public float slashDelay = 0.53f;

    public int health;
    public string entityName;
    public int baseAttack;


    void Start()
    {
        currentState = CharacterState.IDLE;
        characterRigidBody = GetComponent<Rigidbody2D>();
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    void Update()
    {

        // isAttacking = IsAttacking();

        // if (Input.GetButtonDown("slash") && !isAttacking)
        // {
        //     StartCoroutine(PlaySlash());
        // }
        // // Don't update animation if we are attacking, let it play out.
        // else if (currentState <= CharacterState.WALK)
        // {
        //     UpdateAnimation();
        // }
    }

    void FixedUpdate()
    {
        // Physics based on fixed update rate
        if (!isAttacking)
        {
            characterRigidBody.MovePosition(characterRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    protected void UpdateAnimation()
    {
        lastDirection = CheckDirection();

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


    protected CardinalDirection CheckDirection()
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

    // Update this if/when we add additional attack types.
    protected bool IsAttacking()
    {
        return currentState == CharacterState.SLASH;
    }

    protected IEnumerator PlaySlash()
    {
        lastDirection = CheckDirection();
        currentState = CharacterState.SLASH;
        characterAnimation.ChangeAnimationState(lastDirection, currentState);
        // yield return null;
        yield return new WaitForSeconds(slashDelay);
        currentState = CharacterState.WALK;
    }
}
