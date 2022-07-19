﻿using adventofcode_2015.Task42;
using System.Collections.Generic;
using Xunit;

namespace adventofcode_2015.Tests.Task42
{
    public class SolutionTests
    {
        [Fact]
        public void Task42_RealExample_Correct()
        {
            var spells = new List<Spell>
{               new Spell
                {
                    Name = "Magic Missile",
                    ManaCost = 53,
                    Damage = 4
                },
                new Spell
                {
                    Name = "Drain",
                    ManaCost = 73,
                    Damage = 2,
                    Heal = 2
                },
                new Spell
                {
                    Name = "Shield",
                    ManaCost = 113,
                    EffectLasting = 6,
                    Armor = 7
                },
                new Spell
                {
                    Name = "Poison",
                    ManaCost = 173,
                    EffectLasting = 6,
                    Damage = 3
                },
                new Spell
                {
                    Name = "Recharge",
                    ManaCost = 229,
                    EffectLasting = 5,
                    Mana = 101
                }
            };

            var enemyStats = new BossStats
            {
                Damage = 8,
                HitPoints = 13
            };

            var playerStats = new PlayerStats
            {
                HitPoints = 20,
                Mana = 250
            };

            Assert.Equal(226, Solution.Function(spells, enemyStats, playerStats));
        }
    }
}