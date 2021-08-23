using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DungeonGenerator), true)]
public class LayoutGeneratorEditor : Editor
{
    DungeonGenerator dungeonGenerator;

    private void Awake()
    {
        dungeonGenerator = (DungeonGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Dungeon"))
        {
            dungeonGenerator.RunLayoutGen();
        }

        if (GUILayout.Button("Clear Dungeon"))
        {
            dungeonGenerator.ClearLayoutGen();
        }
    }
}
