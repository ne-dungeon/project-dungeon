using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// How to make a parent class that template generators must adhere to/inherit from?
/// <summary>Abstract class for calling template generation depending on theme.</summary>
public abstract class ThemeTemplates
{
    protected int roomHeight;
    protected int roomWidth;

    protected ThemeTemplates(int roomHeight = 8, int roomWidth = 12)
    {
        this.roomHeight = roomHeight;
        this.roomWidth = roomWidth;
    }

    /// <summary>Generates a template that will work for any assortment of doors.</summary>
    public abstract TilePositionTemplate Get();

}

