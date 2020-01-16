using Raptor.Utility;
using UnityEngine;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Generates a dungeon floor based on rules
    /// Handles scripted rooms,  etc.
    /// </summary>
    public abstract class DungeonCrawlerDirector
    {
        DungeonRules _rules;
        int _seed;

        public DungeonCrawlerDirector(DungeonRules rules, int seed = 0)
        {
            this._rules = rules;
            this._seed = seed;
        }
    }

    /// <summary>
    /// Default dungeon data generator
    /// </summary>
    public class JollyJennyDirector : DungeonCrawlerDirector
    {
        public JollyJennyDirector(DungeonRules rules, int seed = 0) : base(rules, seed)
        {
        }
    }

    /// <summary>
    /// Generates plans with wide spans between attributes
    /// E.g. wide rooms, but fewer enemies
    /// Or less rooms, but with mulitple bosses, etc.
    /// </summary>
    public class MentalMarcGenerator : DungeonCrawlerDirector
    {
        public MentalMarcGenerator(DungeonRules rules, int seed = 0) : base(rules, seed)
        {
        }
    }

    /// <summary>
    /// Truly random values within reason
    /// </summary>
    public class RandomRamiGenerator : DungeonCrawlerDirector
    {
        public RandomRamiGenerator(DungeonRules rules, int seed = 0) : base(rules, seed)
        {
        }
    }

    public class DungeonDirectorFactory
    {
        public enum CrawlerDirectorNames
        {
            JollyJenny,
            MentalMarc,
            RandomRami
        }
    }
}
