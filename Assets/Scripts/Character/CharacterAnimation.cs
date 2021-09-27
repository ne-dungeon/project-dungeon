using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Do not change the names of these, they convert toString to the string names of
    // the animations!
    public enum AnimationName {
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
    private AnimationName currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(CardinalDirection direction, CharacterControl.CharacterState state)
    {
        AnimationName newAnimation = CharacterAnimation.AnimationName.IdleS;


        if (state == CharacterControl.CharacterState.WALK)
        {
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    currentAnimation = CharacterAnimation.AnimationName.WalkN;
                    break;
                case CardinalDirection.WEST:
                    currentAnimation = CharacterAnimation.AnimationName.WalkW;
                    break;
                case CardinalDirection.SOUTH:
                    currentAnimation = CharacterAnimation.AnimationName.WalkS;
                    break;
                case CardinalDirection.EAST:
                    currentAnimation = CharacterAnimation.AnimationName.WalkE;
                    break;
            }
        }
        else
        {
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    currentAnimation = CharacterAnimation.AnimationName.IdleN;
                    break;
                case CardinalDirection.WEST:
                    currentAnimation = CharacterAnimation.AnimationName.IdleW;
                    break;
                case CardinalDirection.SOUTH:
                    currentAnimation = CharacterAnimation.AnimationName.IdleS;
                    break;
                case CardinalDirection.EAST:
                    currentAnimation = CharacterAnimation.AnimationName.IdleE;
                    break;
            }
        }

        // Don't allow animation to interrupt itself
        if (currentAnimation == newAnimation)
        {
            return;
        }

        // Play the input animation
        animator.Play(newAnimation.ToString());

        // Reassign the current state
        currentAnimation = newAnimation;
    }
}
