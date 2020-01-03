using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GenerateRoom))]
public class GenerateDungeon : MonoBehaviour
{
    [SerializeField] Grid worldGrid;
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] Tilemap obstacleTilemap;

    public void TestGenerate()
    {
        Debug.Log("Generate dungeon");
    }

    public void ResetDungeon()
    {
        Debug.Log("Resetting dungeon");
    }
}
