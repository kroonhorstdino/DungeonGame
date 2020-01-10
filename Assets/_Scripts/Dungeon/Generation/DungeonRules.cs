using System.Collections.Generic;
using UnityEngine;

namespace RocketRaptor.Dungeon.Generation
{
    [CreateAssetMenu(fileName = "DungeonRules", menuName = "Dungeon/DungeonRules", order = 0)]
    public class DungeonRules : ScriptableObject
    {
        public int _numFloors;

        public FloorRules _rules;
    }

    public class ScriptedDungeonRules : DungeonRules
    {
        FloorRules _scriptedRules;
    }

    [CreateAssetMenu(fileName = "FloorRules", menuName = "Dungeon/FloorRules", order = 0)]
    public class FloorRules : ScriptableObject
    {
        public int _numRooms;
    }

}
