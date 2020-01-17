using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using Raptor.Dungeon.Generation;
using Raptor.Dungeon;

namespace RocketRaptor.EditorExtension
{
    [CustomEditor(typeof(DungeonGenerator))]
    public class GenerateDungeonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("MANUAL DUNGEON GENERATION");

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

    [CustomEditor(typeof(DungeonRoom))]
    public class DungeonRoomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            DungeonRoom room = (DungeonRoom)target;
            EditorGUILayout.Separator();
        }
    }
}
