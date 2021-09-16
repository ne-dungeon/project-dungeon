using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    slash,
    interact
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float moveSpeed = 4f;

    private Rigidbody2D playerRigidBody;
    private Animator animator;

    Vector2 movement;

    void Start()
    {
        currentState = PlayerState.walk;
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input based on framerate
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (Input.GetButtonDown("slash") && !isAttacking())
        {
            StartCoroutine(SlashCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    void FixedUpdate()
    {
        // Physics based on fixed update rate
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateAnimationAndMove()
    {

        // Set the animator movement for walking animations.
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Set the animator last direction for idle animations.
        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
    }

    private IEnumerator SlashCo()
    {
        animator.SetBool("Slashing", true);
        currentState = PlayerState.slash;
        yield return null;
        animator.SetBool("Slashing", false);
        yield return new WaitForSeconds(0.33f);
        currentState = PlayerState.walk;
    }

    // Update this if/when we add additional attack types.
    bool isAttacking()
    {
        return currentState == PlayerState.slash;
    }
}
