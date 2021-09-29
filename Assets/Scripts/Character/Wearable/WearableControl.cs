using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearableControl : MonoBehaviour
{
    private Animator[] wearableAnimators;

    // Start is called before the first frame update
    void Start()
    {
        wearableAnimators = GetComponentsInChildren<Animator>();
    }

    public void UpdateAnimations(CharacterAnimation.AnimationName animationName)
    {
        foreach (Animator animator in wearableAnimators)
        {
            animator.Play(animationName.ToString());
        }
    }
}
