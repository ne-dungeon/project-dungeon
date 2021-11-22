using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if(collisionObject.CompareTag("Breakable")) 
        {
            collisionObject.GetComponent<Breakable>().Break();
        }
    }
}
