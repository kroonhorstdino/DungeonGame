using UnityEngine;
using System.Collections;
using UnityEditor;

using RocketRaptor.Dungeon.Generation;

[CustomEditor(typeof(DungeonGenerator))]
public class GenerateDungeonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Generate Dungeon with parameters:");

        DungeonGenerator generateDungeon = (DungeonGenerator)target;
        if (GUILayout.Button("Generate Dungeon"))
        {
            generateDungeon.TestGenerate();
        }
    }
}
