using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// How to make a parent class that template generators must adhere to/inherit from?
/// <summary>Abstract class for calling template generation depending on theme.</summary>
public abstract class ThemeTemplates : MonoBehaviour
{
    /// <summary>Generates a template that will work for any assortment of doors.</summary>
    public abstract HashSet<Vector2Int> DoorsAny();

}

