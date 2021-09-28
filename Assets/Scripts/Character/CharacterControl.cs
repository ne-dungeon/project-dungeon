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

    public CharacterState currentState;
    public CardinalDirection lastDirection = CardinalDirection.SOUTH;

    public float moveSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
