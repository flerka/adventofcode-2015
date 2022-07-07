using adventofcode_2015.Task40;
using System.Collections.Generic;
using Xunit;

namespace adventofcode_2015.Tests.Task40
{
    public class SolutionTests
    {
        [Fact]
        public void Task40_RealExample_Correct()
        {
            var shop = new Shop
            {
                WeaponItems = new List<ItemStats>
                {
                    new ItemStats("Dagger", 8, 4, 0),
                    new ItemStats("Shortsword", 10, 5, 0),
                    new ItemStats("Warhammer", 25, 6, 0),
                    new ItemStats("Longsword", 40, 7, 0),
                    new ItemStats("Greataxe", 74, 8, 0)
                },
                ArmorItems = new List<ItemStats> {
                    new ItemStats("Leather", 13, 0, 1),
                    new ItemStats("Chainmail", 31, 0, 2),
                    new ItemStats("Splintmail", 53, 0, 3),
                    new ItemStats("Bandedmail", 75, 0, 4),
                    new ItemStats("Platemail", 102, 0, 5)
                },
                RingItems = new List<ItemStats>
                {
                    new ItemStats("Damage +1", 25, 1, 0),
                    new ItemStats("Damage +2",50, 2, 0),
                    new ItemStats("Damage +3", 100, 3, 0),
                    new ItemStats("Defense +1", 20, 0, 1),
                    new ItemStats("Defense +2", 40, 0, 2),
                    new ItemStats("Defense +3", 80, 0, 3)
                }
            };

            var enemyStats = new UserStats
            {
                Damage = 8,
                Armor = 1,
                HitPoints = 40
            };

            var myHitPoints = 100;
            Assert.Equal(8, Solution.Function(shop, enemyStats, myHitPoints));
        }
    }
}