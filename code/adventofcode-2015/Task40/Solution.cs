using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task40
{
    public class UserStats
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }

    public class ItemStats
    {
        public ItemStats(string name, int cost, int damage, int armor)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; set; }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }

    public class Shop
    {
        public List<ItemStats> ArmorItems { get; set; }
        public List<ItemStats> RingItems { get; set; }
        public List<ItemStats> WeaponItems { get; set; }
    }

    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2015/day/21/ task
        /// </summary>
        public static int Function(Shop shop, UserStats enemyStats, int hitPoints)
        {
            var weapons = shop.WeaponItems;
            var armors = new List<ItemStats>(shop.ArmorItems);
            armors.Add(new ItemStats("default", 0, 0, 0));

            var ringsCombinations = GetRingsCombinations(shop.RingItems);
            ringsCombinations.Add(new List<ItemStats> { });
            double maxGold = double.NegativeInfinity;
            foreach (var weapon in weapons)
            {
                foreach (var armor in armors)
                {
                    foreach (var ringsComb in ringsCombinations)
                    {
                        var resultStats = GetTotalStats(weapon, armor, ringsComb);
                        var isWin = Simulate(resultStats.Item1, enemyStats);
                        if (!isWin)
                        {
                            maxGold = Math.Max(maxGold, resultStats.Item2);
                        }
                    }
                }
            }

            return (int)maxGold;
        }

        private static bool Simulate(UserStats me, UserStats enemy)
        {
            var meResult = (int)Math.Ceiling((double)me.HitPoints / (double)Math.Max(enemy.Damage - me.Armor, 1));
            var enemyResult = (int)Math.Ceiling((double)enemy.HitPoints / (double)Math.Max(me.Damage - enemy.Armor, 1));
            return meResult >= enemyResult;
        }

        private static (UserStats, int) GetTotalStats(ItemStats weapon, ItemStats armor, List<ItemStats> rings)
        {
            var result = new UserStats();
            result.HitPoints = 100;
            var cost = weapon.Cost + armor.Cost + rings.Select(i => i.Cost).Sum();

            result.Damage += weapon.Damage + armor.Damage + rings.Select(i => i.Damage).Sum();
            result.Armor += weapon.Armor + armor.Armor + rings.Select(i => i.Armor).Sum();

            return (result, cost);
        }

        /// <summary>
        /// Based on - https://stackoverflow.com/a/7802892/3653606 this answer
        /// </summary>
        private static List<List<ItemStats>> GetRingsCombinations(List<ItemStats> rings)
        {
            var result = new List<List<ItemStats>>();
            var count = Math.Pow(2, rings.Count);
            for (var i = 1; i <= count - 1; i++)
            {
                var temp = new List<ItemStats>();
                var str = Convert.ToString(i, 2).PadLeft(rings.Count, '0');
                for (var j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        temp.Add(rings[j]);
                    }
                }

                result.Add(temp);
            }

            return result.Where(i => i.Count <= 2).ToList();
        }
    }
}