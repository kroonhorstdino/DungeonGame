using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

namespace Raptor.Dungeon
{
    //TODO: Maybe transfer grid functions to a separate class? (In utility for example?)
    using Generation;

    /// <summary>
    /// Handles all matters about the dungeon during gameplay, also contains functions related to operations on the grid
    /// Generation is in separate class
    /// Essentially the "world class"
    /// </summary>
    public class Dungeon : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] DungeonGenerator generator;

        [Header("World")]
        [SerializeField] Grid _worldGrid;
        [SerializeField] Tilemap _groundTilemap;
        [SerializeField] Tilemap _obstacleTilemap;

        [Header("Dungeon")]
        [Tooltip("Current floor of dungeon")]
        [SerializeField] int _currentFloor;

        [SerializeField] DungeonLayout _layout;

        public Vector3Int CenterPoint { get => _centerPoint; }
        public int CurrentFloor { get => _currentFloor; }
        public DungeonLayout Layout { get => _layout; }

        //Center point for crawlers
        [SerializeField] Vector3Int _centerPoint;

        private void Awake()
        {
            _layout = new DungeonLayout();
        }

        public void SnapToGrid(DungeonRoom room)
        {
            room.transform.position = _worldGrid.WorldToCell(room.transform.position);
        }

        void OnDestroy()
        {
            _layout.OnDestroy();
        }
    }
}