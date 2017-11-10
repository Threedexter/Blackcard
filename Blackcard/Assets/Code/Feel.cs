using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feel
{
    public readonly static Feel Grassland;
    public readonly static Feel Marsh;
    public readonly static Feel Mountain;
    public readonly static Feel Ruins;
    public readonly static Feel Start;

    static Feel()
    {
        Start = new Feel()
        {
            name = "Grass",
            spawn_enemy_chance = 0,
            movement_cost = 1,
            spawn_loot_chance = 0,
            blocked_sides = new MinMax(0,0),

            magicalMightEnemy = new MinMax(0, 0),
            physicalMightEnemy = new MinMax(0, 0),

            magicalMightLoot = new MinMax(0, 0),
            physicalMightLoot = new MinMax(0, 0),
            turnLoot = new MinMax(0, 0)
        };
        Grassland = new Feel()
        {
            name = "Grass",
            spawn_enemy_chance = 60,
            movement_cost = 1,
            spawn_loot_chance = 10,
            blocked_sides = new MinMax(0, 2),

            magicalMightEnemy = new MinMax(60, 120),
            physicalMightEnemy = new MinMax(90, 120),

            magicalMightLoot = new MinMax(10, 20),
            physicalMightLoot = new MinMax(5, 10),
            turnLoot = new MinMax(0, 3)
        };
        Marsh = new Feel()
        {
            name = "Marsh",
            spawn_enemy_chance = 30,
            movement_cost = 2,
            spawn_loot_chance = 10,
            blocked_sides = new MinMax(1, 2),

            magicalMightEnemy = new MinMax(90, 125),
            physicalMightEnemy = new MinMax(100, 150),

            magicalMightLoot = new MinMax(20, 25),
            physicalMightLoot = new MinMax(15, 30),
            turnLoot = new MinMax(2, 4)
        };
        Mountain = new Feel()
        {
            name = "Mountain",
            spawn_enemy_chance = 30,
            movement_cost = 3,
            spawn_loot_chance = 10,
            blocked_sides = new MinMax(1, 3),

            magicalMightEnemy = new MinMax(100, 150),
            physicalMightEnemy = new MinMax(90, 120),

            magicalMightLoot = new MinMax(20, 25),
            physicalMightLoot = new MinMax(10, 15),
            turnLoot = new MinMax(2, 4)
        };
        Ruins = new Feel()
        {
            name = "Ruins",
            spawn_enemy_chance = 30,
            movement_cost = 2,
            spawn_loot_chance = 30,
            blocked_sides = new MinMax(1, 4),

            magicalMightEnemy = new MinMax(80, 120),
            physicalMightEnemy = new MinMax(80, 120),

            magicalMightLoot = new MinMax(20, 25),
            physicalMightLoot = new MinMax(10, 15),
            turnLoot = new MinMax(2, 4)
        };
    }

    public string name;
    public int spawn_enemy_chance;
    public int spawn_loot_chance;
    public int movement_cost;

    /// <summary>
    /// Blocked sides
    /// </summary>
    public MinMax blocked_sides;

    // Enemy

    /// <summary>
    /// Magical might relative to the player
    /// </summary>
    public MinMax magicalMightEnemy;

    /// <summary>
    /// Physical might relative to the player
    /// </summary>
    public MinMax physicalMightEnemy;

    // Loot

    /// <summary>
    /// Physical might from loot
    /// </summary>
    public MinMax physicalMightLoot;

    /// <summary>
    /// Magical might from loot
    /// </summary>
    public MinMax magicalMightLoot;

    /// <summary>
    /// Turn loot
    /// </summary>
    public MinMax turnLoot;

    private Feel()
    {
    }

    public static Feel RandomFeel()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                return Feel.Grassland;
            case 1:
                return Feel.Marsh;
            case 2:
                return Feel.Mountain;
            case 3:
                return Feel.Ruins;
        }
        return Grassland;
    }

    public class MinMax
    {
        /// <summary>
        /// Inclusive minimum
        /// </summary>
        public int min;

        /// <summary>
        /// Inclusive maximum
        /// </summary>
        public int max;

        /// <summary>
        /// generated number, generated on get
        /// </summary>
        public int Generated
        {
            get
            {
                return Random.Range(min, max + 1);
            }
        }

        public MinMax(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
