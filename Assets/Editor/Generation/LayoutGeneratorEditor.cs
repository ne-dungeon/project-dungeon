using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LayoutGenerator), true)]
public class LayoutGeneratorEditor : Editor
{
    LayoutGenerator layoutGenerator;

    private void Awake()
    {
        layoutGenerator = (LayoutGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Dungeon Prefabs"))
        {
            layoutGenerator.CreateLayout();
            layoutGenerator.CreatePrefabLayout();
        }

        if (GUILayout.Button("Clear Dungeon Prefabs"))
        {
            layoutGenerator.ClearPrefabLayout();
        }
    }
}
