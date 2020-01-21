using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Utility.Math;

namespace Raptor.Dungeon.Generation
{
    public class TilePlacer
    {
        private Tilemap _groundTilemap;
        private Tilemap _obstaclesTilemap;


        public TilePlacer(Tilemap groundTilemap, Tilemap obstaclesTilemap)
        {
            this._obstaclesTilemap = obstaclesTilemap;
            this._groundTilemap = groundTilemap;
        }

        public void TileStructure(DungeonRoom room)
        {
            Debug.Log("Tiling room " + room.ID);

            TileBase groundTile = room._rules._groundTile;
            BoundsInt b = room.Collider.bounds.ToInt();

            Vector3Int[] positions = new Vector3Int[b.size.x * b.size.y];
            TileBase[] arr = new TileBase[b.size.x * b.size.y];

            //Fill both arrays with positions on XY plane (z == 0)
            int i = 0;
            foreach (Vector3Int pos in b.allPositionsWithin)
            {
                //Only pos on XY plane
                if (pos.z != 0) continue;

                positions[i] = pos;
                arr[i] = groundTile;

                i++;
            }

            //_groundTilemap.SetTiles(positions, arr);

            _groundTilemap.SetTilesBlock(b, arr);



            Debug.Log("Heylo");

            //TODO:Test this line
            //_groundTilemap.BoxFill(b.center.ToInt(), groundTile, b.xMin, b.yMin, b.xMax, b.yMax);
        }
    }
}
