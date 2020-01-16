using UnityEngine;
using System.Collections;
using UnityEditor;

using Raptor.Dungeon.Generation;

[CustomEditor(typeof(DungeonGenerator))]
public class GenerateDungeonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Generate Dungeon with parameters:");

        DungeonGenerator dungeonGenerator = (DungeonGenerator)target;
        if (GUILayout.Button("Generate Dungeon"))
        {
            if (!EditorApplication.isPlaying)
            {
                Debug.LogError("Generation has to be done in playmode to execute properly!");

            }
            else
            {
                dungeonGenerator.TestGenerate();
            }
        }

        if (GUILayout.Button("Reset Dungeon"))
        {
            dungeonGenerator.ResetDungeon();
        }

        EditorGUILayout.Separator();

        if (GUILayout.Button("RESET GENERATOR"))
        {
            dungeonGenerator.ResetGenerator();
        }
    }
}
