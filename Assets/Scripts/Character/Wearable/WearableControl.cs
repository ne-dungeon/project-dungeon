using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearableControl : MonoBehaviour
{
    // public GameObject parentBody;

    private CharacterControl parentControl;
    private CharacterAnimation wearableAnimation;

    public CharacterControl.CharacterState wearableState;
    public CardinalDirection wearableDirection;

    // Start is called before the first frame update
    void Start()
    {
        parentControl = GetComponentInParent<CharacterControl>();
        wearableAnimation = GetComponent<CharacterAnimation>();
        wearableState = parentControl.currentState;
        wearableDirection = parentControl.lastDirection;
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        wearableState = parentControl.currentState;
        wearableDirection = parentControl.lastDirection;

        wearableAnimation.ChangeAnimationState(wearableDirection, wearableState);
    }
}
