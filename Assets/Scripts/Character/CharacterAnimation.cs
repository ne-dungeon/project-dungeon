using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Do not change the names of these, they convert toString to the string names of
    // the animations!
    public enum CharacterState {
        IdleN,
        IdleW,
        IdleS,
        IdleE,
        WalkN,
        WalkW,
        WalkS,
        WalkE
    }

    Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeAnimationState(string newState)
    {
        // Don't allow animation to interrupt itself
        if (currentState == newState)
        {
            return;
        }

        // Play the input animation
        animator.Play(newState);

        // Reassign the current state
        currentState = newState;
    }
}
