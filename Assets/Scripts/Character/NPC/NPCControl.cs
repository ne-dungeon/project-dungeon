using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : CharacterControl
{
    // Start is called before the first frame update
    void Start()
    {
        currentState = CharacterState.IDLE;
        characterRigidBody = GetComponent<Rigidbody2D>();
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
