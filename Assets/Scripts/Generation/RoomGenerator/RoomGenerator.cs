using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes the details of a room generated from the dungeon generator and creates 
/// a room Game object matching those details.
/// </summary>
public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    RoomDetails details;

    public RoomGenerator(RoomDetails details) {
        this.details = details;
    }
    
    public void Generate(RoomDetails details) {
        // 1. Generate the basic room. Uses details: theme, doors, startroom, levelboss, goesdown.
            // Selects a template from the theme that matches the quantity and direction of non-none doors.
            // If it's a boss room, selects from specifically boss room templates.
            // Add stairs up or stairs down as appropriate.
        // 2. Place minions/minibosses/nonhostiles per details. uses difficultyDepth
        //    (to pick which groups to pull npcs from), minions, minibosses, levelboss.
        // 3. Check for puzzles. If a puzzle is present, generate according to the puzzle type. 
        //    Uses puzzle, treasure. (Should remove treasure if used in generation, or maybe return 'remaining treasure')
        // 4. Place any treasure remaining after the puzzle step. Uses treasure
        // 5. Add random obstacles, decor, etc. Needs to guarantee that it does not block pathing. 
        // 6. Returns the assembled game object 
    }
}
