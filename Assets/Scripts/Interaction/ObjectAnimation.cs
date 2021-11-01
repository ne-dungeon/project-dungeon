using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    // Do not change the names of these, they convert toString to the string names of
    // the animations!
    public enum AnimationName
    {
        Idle,
        Destroy
    }

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(AnimationName.Idle.ToString());
    }
    
    public void Break()
    {
        animator.Play(AnimationName.Destroy.ToString());
    }
}
