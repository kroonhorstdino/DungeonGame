using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Raptor.Utility;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Adjust colliders of rooms
    /// </summary>
    public class NeighbourSearchAgent : ILayoutGeneratorAgent
    {
        DungeonLayout _layout;

        public NeighbourSearchAgent(DungeonLayout layout)
        {
            _layout = layout;
        }

        /// <summary>
        /// Adjusts room gameobject for all rooms, so that they are positioned correctly on the grid
        /// </summary>
        /// <param name="layout"></param>
        public void SetNeighboursAllRooms()
        {
            _layout.ApplyToEachRoom((DungeonRoom r) => SetNeighbour(r));
        }

        /// <summary>
        /// Adjusts size of one collider of one room
        /// Uses different functions based on type of collider (NOTE: Yet to be useful, waiting for edge colliders to be used...)
        /// </summary>
        /// <param name="r"></param>
        public static void SetNeighbour(DungeonRoom r)
        {
            List<DungeonRoom> neighbours;
            if (r.Collider.GetType() == typeof(BoxCollider2D))
            {
                SearchNeighboursSimple(r, out neighbours);
            }
            else
            {
                throw new NotImplementedException();
            }

            //Set neighbours for one room
            r.SetNeighbourhood(neighbours);
        }

        /// <summary>
        /// Returns neighbours of room.
        /// Shifts collider around to check each separate direction.
        /// Does not simply extend bounds to prevent detecting diagonal rooms
        /// </summary>
        /// <param name="r"></param>
        static void SearchNeighboursSimple(DungeonRoom r, out List<DungeonRoom> neighbours)
        {
            List<int> directions = new List<int>() { 0, 2, 4, 6 };
            neighbours = new List<DungeonRoom>();
            List<Collider2D> neighboursCollider = new List<Collider2D>();

            Vector3 originalPosition = r.Collider.bounds.center;
            Vector3 originalSize = r.Collider.bounds.size + new Vector3(-0.3f, -0.3f, 0f);

            // Iterate through main cardinal directions (add 2 to direction)
            foreach (GridDirection gridDir in directions)
            {
                Vector3 dirVector = (Vector3)GridUtility.GetNormalizedDirectionVector(gridDir);

                //Use modified bounds to get colliders in that direction
                Vector3 newPos = originalPosition + dirVector * 0.5f;

                ///=== Check for overlapping colliders
                List<Collider2D> neighboursInDir = Physics2D.OverlapBoxAll(newPos, originalSize, 0f).ToList();

                //Convert all colliders into dungeon rooms and assign set as list
                neighbours.AddRange(neighboursInDir.ConvertAll(c => c.GetComponent<DungeonRoom>()));
            }

            //Remove own colliders
            neighbours.RemoveAll(room => r.ID == room.ID);
        }
    }
}