using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Template), true)]
public class TemplateGeneratorEditor : Editor
{
    Template template;

    private void Awake()
    {
        template = (Template)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Get Template")) {
            Debug.Log("Get template button pressed");
            template.RunGetTemplate();
        }

        if(GUILayout.Button("Clear Tilemaps")) {
            Debug.Log("Clear template button pressed");
            template.ClearAllTileMaps();
        }
    }
}
