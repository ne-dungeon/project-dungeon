using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    private Rigidbody2D playerRigidBody;
    private Animator animator;

    Vector2 movement;

    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input based on framerate
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

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

    void FixedUpdate()
    {
        // Physics based on fixed update rate
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
