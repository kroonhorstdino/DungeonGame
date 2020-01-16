using UnityEngine;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Creates one room with different shapes, sizes, etc.
    /// </summary>
    public class RoomGenerator
    {
        protected DungeonRoomRules _roomRules;
        protected GameObject _roomObject;

        public RoomGenerator(DungeonRoomRules roomRules)
        {
            _roomRules = roomRules;
        }

        /// <summary>
        /// Generate room with matching collider
        /// </summary>
        /// <returns></returns>
        public DungeonRoom GenerateRoom()
        {
            //Initialize GameObject
            CreateRoomObject();
            //Generate the shape as collider
            GenerateRoomShape();
            //Finally add script

            DungeonRoom room = _roomObject.AddComponent<DungeonRoom>();
            room.ID = DungeonRoom.GetNextID();
            room.gameObject.name = "Room " + room.ID.ToString();

            return room;
        }

        /// <summary>
        /// Generates dungeon room gameobject with all its components
        /// </summary>
        protected virtual void CreateRoomObject()
        {
            //Create new Room Object
            _roomObject = new GameObject();

            _roomObject.transform.position = Vector3Int.zero;
            _roomObject.transform.rotation = Quaternion.identity;

            Rigidbody2D rg = _roomObject.AddComponent<Rigidbody2D>();
            rg.gravityScale = 0f;
            rg.freezeRotation = true;

            //Simulate!
            rg.simulated = true;
        }

        /// <summary>
        /// Create collider and shape it based on rules
        /// </summary>
        /// <param name="collider"></param>
        protected virtual void GenerateRoomShape()
        {
            new SimpleRoomShaper().AddShapedCollider(_roomRules, _roomObject);
        }
    }

    /// <summary>
    /// Classes that provide methods for shaping room colliders
    /// </summary>
    public interface RoomShaper
    {
        /// <summary>
        /// Adds collider and shapes it on gameobject
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="roomObject"></param>
        void AddShapedCollider(DungeonRoomRules rules, GameObject roomObject);
    }

    /// <summary>
    /// Creates simple room shapes
    /// </summary>
    public class SimpleRoomShaper : RoomShaper
    {
        public void AddShapedCollider(DungeonRoomRules rules, GameObject _roomObject)
        {
            _roomObject.AddComponent<BoxCollider2D>();

            Bounds b = _roomObject.GetComponent<BoxCollider2D>().bounds;

            //Size of bounds
            float xSize = rules._xSize.PickRoundedInt();
            float ySize = rules._ySize.PickRoundedInt();

            float xCenter = b.center.x;
            float yCenter = b.center.y;

            Vector3 boundsMin = new Vector3(b.center.x - xSize * 0.5f, b.center.x - ySize * 0.5f, 0);
            Vector3 boundsMax = new Vector3(b.center.x + xSize * 0.5f, b.center.x + ySize * 0.5f, 0);

            //Set extents
            b.SetMinMax(boundsMin, boundsMax);

            BoxCollider2D col = _roomObject.GetComponent<BoxCollider2D>();
            col.offset = b.center;
            col.size = b.size;
            //col.sharedMaterial.friction = 1f;
            //col.isTrigger = true; //Needs colliders for simulation, change back later
        }
    }
}
