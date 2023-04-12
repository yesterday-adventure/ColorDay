using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColorChanger))]
public class ColorChangerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ColorChanger cc = target as ColorChanger;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Color"))
        {
            cc.GenerateColor();
        }
        if (GUILayout.Button("Reset Color"))
        {
            cc.ResetColor();
        }
        GUILayout.EndHorizontal();
    }
}