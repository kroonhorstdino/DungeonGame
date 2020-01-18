using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

using Raptor.Dungeon.Generation;
using Raptor.Dungeon;
using Raptor.Utility.Grid;

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

            if (GUILayout.Button("Check for neighbours"))
            {
                      List<DungeonRoom> neighbours = new List<DungeonRoom>();
            List<Collider2D> neighboursCollider = new List<Collider2D>();

            Vector3 originalPosition = room.Collider.bounds.center;
            Vector3 originalSize = room.Collider.bounds.size + new Vector3(-0.3f, -0.3f);
            
                Vector3 dirVector = (Vector3)GridUtility.GetNormalizedDirectionVector(0);

                //Use modified bounds to get colliders in that direction
                Vector3 newPos = originalPosition + dirVector;

                ///=== Check for overlapping colliders
                room.transform.position = newPos;
                ((BoxCollider2D)(room.Collider)).size = originalSize;
            }
        }
    }
}
