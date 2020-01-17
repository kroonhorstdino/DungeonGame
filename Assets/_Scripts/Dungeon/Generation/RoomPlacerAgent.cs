using System.Collections.Generic;
using UnityEngine;
using Raptor.Utility;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Generator Agent that places rooms based on dungeon and room rules
    /// </summary>
    public class InitialRoomPlacerAgent : IIntializerAgent
    {
        DungeonFloorRules _floorRules;

        int _numInitialRooms = 50;
        BoundsInt _initialPlacementBounds = new BoundsInt(Vector3Int.zero, new Vector3Int(20, 20, 0));

        public InitialRoomPlacerAgent(DungeonFloorRules floorRules)
        {
            _floorRules = floorRules;
        }

        public List<DungeonRoom> GenerateRooms()
        {
            List<DungeonRoom> rooms = new List<DungeonRoom>();

            for (int i = 0; i < _numInitialRooms; i++)
            {
                RoomGenerator roomGen = new RoomGenerator(ChooseRoomRules());
                DungeonRoom room = roomGen.GenerateRoom();

                /**
                 * First room (ID 0) acts as anchor of other rooms, thus it is not allowed to move during body simulation
                 * All other rooms are placed at random position within initial room placement bounds
                 * */
                if (room.ID != 0)
                {
                    //Pick random point
                    room.transform.position = Randomizer.PickPointInt(_initialPlacementBounds);
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
        protected virtual DungeonRoomRules ChooseRoomRules()
        {
            return Randomizer.PickWeightedOption(_floorRules._weightedRoomRules);
        }
    }
}
