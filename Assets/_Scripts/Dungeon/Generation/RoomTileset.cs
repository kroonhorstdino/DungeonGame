using UnityEngine;
using UnityEngine.Tilemaps;

namespace RocketRaptor.Dungeon
{
    namespace Generation
    {
        [CreateAssetMenu(fileName = "RoomTileset", menuName = "Dungeon/RoomTileset", order = 0)]
        public class RoomTileset : ScriptableObject
        {
            [SerializeField]
            readonly Tile _groundTile;
        }

    }
}