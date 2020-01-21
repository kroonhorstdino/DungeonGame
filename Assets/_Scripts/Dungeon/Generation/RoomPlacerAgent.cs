using System.Collections.Generic;
using UnityEngine;
using Raptor.Utility;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Generator Agent that places rooms based on dungeon and room rules
    /// </summary>
    public class InitialRoomPlacerAgent : ILayoutGeneratorAgent
    {
        Randomizer _random;

        int _numInitialRooms = 50;
        FloorRules _floorRules;

        BoundsInt _initialPlacementBounds = new BoundsInt(Vector3Int.zero, new Vector3Int(75, 75, 0));

        public InitialRoomPlacerAgent(ref Randomizer randomizer, FloorRules floorRules)
        {
            _random = randomizer;
            _floorRules = floorRules;
        }

        public List<DungeonRoom> GenerateRooms()
        {
            List<DungeonRoom> rooms = new List<DungeonRoom>();

            for (int i = 0; i < _numInitialRooms; i++)
            {
                RoomGenerator roomGen = new RoomGenerator(ChooseRoomRules(), ref _random);
                DungeonRoom room = roomGen.GenerateRoom();

                /**
                 * First room (ID 0) acts as anchor of other rooms, thus it is not allowed to move during body simulation
                 * All other rooms are placed at random position within initial room placement bounds
                 * */
                if (room.ID != 0)
                {
                    //Pick random point
                    room.transform.position = _random.PickPointInBounds(_initialPlacementBounds);
                }
                //Only first case
                else
                {
                    //Freeze ridigbody in place and set position to zero.
                    room.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    room.transform.position = Vector3Int.zero;
                }
                rooms.Add(room);
            }

            return rooms;
        }

        //TODO: Pick based on weights
        /// <summary>
        /// Picks room rules based on weights
        /// </summary>
        protected virtual RoomRules ChooseRoomRules()
        {
            return _random.PickOptionWeighted(_floorRules._weightedRoomRules);
        }
    }
}
