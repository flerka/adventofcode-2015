using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task43
{
    public enum TurnResult
    {
        BossWon = 1,
        PlayerWon = 2,
        ContinueFight = 3
    }

    public class BossStats
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }

        public BossStats CreateCopy()
        {
            return new BossStats { Damage = Damage, HitPoints = HitPoints };
        }
    }

    public class PlayerStats
    {
        public int HitPoints { get; set; }
        public int Mana { get; set; }
        public int SpentMana { get; set; }
        public int Armor { get; set; }
        public List<Spell> AppliedSpells { get; set; } = new();

        public PlayerStats CreateCopy()
        {
            return new PlayerStats
            {
                HitPoints = HitPoints,
                Mana = Mana,
                SpentMana = SpentMana,
                Armor = Armor,
                AppliedSpells = AppliedSpells.Select(item => item.CreateCopy()).ToList()
            };
        }
    }

    public class Spell
    {
        public string Name { get; set; }

        public int ManaCost { get; set; }

        public int EffectLasting { get; set; }

        public int Damage { get; set; }

        public int Armor { get; set; }

        public int Mana { get; set; }

        public int Heal { get; set; }

        public Spell CreateCopy()
        {
            return new Spell
            {
                Name = Name,
                ManaCost = ManaCost,
                EffectLasting = EffectLasting,
                Armor = Armor,
                Mana = Mana,
                Damage = Damage,
                Heal = Heal
            };
        }
    }

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/22/ task
        /// </summary>
        public static int Function(List<Spell> spells, BossStats boss, PlayerStats player)
        {
            return (int) spells
                .Select(spell =>
                    Simulate(spell.CreateCopy(), spells, boss.CreateCopy(), player.CreateCopy()))
                .ToList()
                .Min();
        }

        public static double Simulate(Spell spell, List<Spell> spells, BossStats enemy, PlayerStats player)
        {
            var turnResult = TurnResult.ContinueFight;

            turnResult = PlayerTurn(spell, enemy, player);
            if (turnResult == TurnResult.ContinueFight)
            {
                turnResult = BossTurn(enemy, player);
            }

            var allowedSpells = spells
                    .Where(item => player.AppliedSpells
                            .Count(item2 => item2.Name == item.Name && item2.EffectLasting > 1) == 0
                            && item.ManaCost <= player.Mana)
                    .ToList();

            return turnResult switch
            {
                TurnResult.PlayerWon => player.SpentMana,
                TurnResult.BossWon => double.PositiveInfinity,
                TurnResult.ContinueFight =>
                    allowedSpells.Count == 0
                    ? double.PositiveInfinity
                    : allowedSpells.Select(spell =>
                        Simulate(spell.CreateCopy(), spells, enemy.CreateCopy(), player.CreateCopy()))
                    .ToList()
                    .Min(),
                _ => throw new NotImplementedException()
            };

        }

        private static TurnResult PlayerTurn(Spell spell, BossStats enemy, PlayerStats player)
        {
            ApplyEffects(enemy, player);
            if (enemy.HitPoints <= 0)
            {
                return TurnResult.PlayerWon;
            }

            ExecuteSpell(spell, enemy, player);

            player.AppliedSpells = player.AppliedSpells.Where(item => item.EffectLasting > 0).ToList();
            player.Armor = 0;

            if (enemy.HitPoints <= 0)
            {
                return TurnResult.PlayerWon;
            }

            return TurnResult.ContinueFight;
        }

        private static void ExecuteSpell(Spell spell, BossStats enemy, PlayerStats player)
        {
            if (spell.ManaCost > player.Mana)
            {
                throw new Exception("inconsistant player state");
            }

            player.Mana -= spell.ManaCost;
            player.SpentMana += spell.ManaCost;
            if (spell.EffectLasting > 0)
            {
                player.AppliedSpells.Add(
                    new Spell
                    {
                        Armor = spell.Armor,
                        Damage = spell.Damage,
                        EffectLasting = spell.EffectLasting,
                        Heal = spell.Heal,
                        Mana = spell.Mana,
                        ManaCost = spell.ManaCost,
                        Name = spell.Name
                    });
            }
            else
            {
                enemy.HitPoints -= spell.Damage;
                player.HitPoints += spell.Heal;
            }
        }

        private static void ApplyEffects(BossStats enemy, PlayerStats player)
        {
            foreach (var effect in player.AppliedSpells)
            {
                effect.EffectLasting--;
                if (effect.Armor > 0)
                {
                    player.Armor = effect.Armor;
                }

                if (effect.Damage > 0)
                {
                    enemy.HitPoints -= effect.Damage;
                }

                if (effect.Mana > 0)
                {
                    player.Mana += effect.Mana;
                }
            }

        }

        private static TurnResult BossTurn(BossStats boss, PlayerStats player)
        {
            ApplyEffects(boss, player);
            if (boss.HitPoints <= 0)
            {
                return TurnResult.PlayerWon;
            }

            player.HitPoints -= Math.Max(boss.Damage - player.Armor, 1);
            if (player.HitPoints <= 0)
            {
                return TurnResult.BossWon;
            }

            player.AppliedSpells = player.AppliedSpells.Where(item => item.EffectLasting > 0).ToList();
            player.Armor = 0;

            return TurnResult.ContinueFight;
        }
    }
}