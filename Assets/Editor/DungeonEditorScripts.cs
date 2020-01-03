using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GenerateDungeon))]
public class GenerateDungeonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Generate Dungeon with parameters:");

        GenerateDungeon generateDungeon = (GenerateDungeon)target;
        if (GUILayout.Button("Generate Dungeon"))
        {
            generateDungeon.TestGenerate();
        }
    }
}
