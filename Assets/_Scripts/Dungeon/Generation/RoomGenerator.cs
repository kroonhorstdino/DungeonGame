using UnityEngine;

using Raptor.Utility;
using Raptor.Utility.Math;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Creates one room based on rules and randomizer
    /// </summary>
    public class RoomGenerator
    {
        protected Randomizer _random;

        protected RoomRules _roomRules;
        protected GameObject _roomObject;

        public RoomGenerator(RoomRules roomRules, ref Randomizer random)
        {
            _random = random;
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
            InitRoomShape();
            //Finally add script

            DungeonRoom room = InitBehavior();

            return room;
        }

        /// <summary>
        /// Creates room object from prefab specified in rules
        /// </summary>
        protected virtual void CreateRoomObject()
        {
            //Create new Room Object
            _roomObject = MonoBehaviour.Instantiate(_roomRules.CorrectGameObject);
        }

        /// <summary>
        /// Create collider and shape it based on rules
        /// </summary>
        /// <param name="collider"></param>
        protected virtual void InitRoomShape()
        {
            //NOTE: This looks fishy
            new SimpleRoomShaper().ShapeCollider(_roomRules, _roomObject, ref _random);
        }

        /// <summary>
        /// Adds behavior to gameobject with proper intialization and then returns it 
        /// </summary>
        /// <returns></returns>
        protected DungeonRoom InitBehavior()
        {
            DungeonRoom room = _roomObject.GetComponent<DungeonRoom>();
            room.ID = DungeonRoom.GetNextID();
            room.SetName();

            room._rules = _roomRules;

            return room;
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
        void ShapeCollider(RoomRules rules, GameObject roomObject, ref Randomizer random);
    }

    /// <summary>
    /// Creates simple room shapes
    /// </summary>
    public class SimpleRoomShaper : RoomShaper
    {
        public void ShapeCollider(RoomRules rules, GameObject _roomObject, ref Randomizer random)
        {
            BoxCollider2D col = _roomObject.GetComponent<BoxCollider2D>();
            Bounds b = col.bounds;

            //Size of bounds
            float xSize = MathUtil.CeilToIntEven(random.PickIntFromRange(rules._xSize));
            float ySize = MathUtil.CeilToIntEven(random.PickIntFromRange(rules._ySize));

            float xCenter = b.center.x;
            float yCenter = b.center.y;

            Vector3 boundsMin = new Vector3(b.center.x - xSize * 0.5f, b.center.x - ySize * 0.5f, 0);
            Vector3 boundsMax = new Vector3(b.center.x + xSize * 0.5f, b.center.x + ySize * 0.5f, 0);

            //Set extents
            b.SetMinMax(boundsMin, boundsMax);

            col.offset = b.center;
            col.size = b.size;
            //col.sharedMaterial.friction = 1f;
            //col.isTrigger = true; //Needs colliders for simulation, change back later
        }
    }
}
