using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Do not change the names of these, they convert toString to the string names of
    // the animations!
    public enum AnimationName
    {
        IdleN,
        IdleW,
        IdleS,
        IdleE,
        WalkN,
        WalkW,
        WalkS,
        WalkE,
        SlashN,
        SlashW,
        SlashS,
        SlashE
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
        AnimationName newAnimation = currentAnimation;

    if (state == CharacterControl.CharacterState.SLASH)
        {
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    newAnimation = CharacterAnimation.AnimationName.SlashN;
                    break;
                case CardinalDirection.WEST:
                    newAnimation = CharacterAnimation.AnimationName.SlashW;
                    break;
                case CardinalDirection.SOUTH:
                    newAnimation = CharacterAnimation.AnimationName.SlashS;
                    break;
                case CardinalDirection.EAST:
                    newAnimation = CharacterAnimation.AnimationName.SlashE;
                    break;
            }
        }
        else if (state == CharacterControl.CharacterState.WALK)
        {
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    newAnimation = CharacterAnimation.AnimationName.WalkN;
                    break;
                case CardinalDirection.WEST:
                    newAnimation = CharacterAnimation.AnimationName.WalkW;
                    break;
                case CardinalDirection.SOUTH:
                    newAnimation = CharacterAnimation.AnimationName.WalkS;
                    break;
                case CardinalDirection.EAST:
                    newAnimation = CharacterAnimation.AnimationName.WalkE;
                    break;
            }
        }
        else if (state <= CharacterControl.CharacterState.INTERACT)
        {
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    newAnimation = CharacterAnimation.AnimationName.IdleN;
                    break;
                case CardinalDirection.WEST:
                    newAnimation = CharacterAnimation.AnimationName.IdleW;
                    break;
                case CardinalDirection.SOUTH:
                    newAnimation = CharacterAnimation.AnimationName.IdleS;
                    break;
                case CardinalDirection.EAST:
                    newAnimation = CharacterAnimation.AnimationName.IdleE;
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
