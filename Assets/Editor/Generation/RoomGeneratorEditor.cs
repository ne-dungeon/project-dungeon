using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomGenerator))]
public class RoomGeneratorEditor : Editor
{

    RoomGenerator roomGen;

    private void Awake()
    {
        roomGen = (RoomGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Room")) {
            Debug.Log("Generate Room Button Pressed");
            roomGen.Generate();
        }
    }
}
