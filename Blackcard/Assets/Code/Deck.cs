using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Deck
{
    public static List<Card> Cards = new List<Card>();

    public List<Card> cards
    {
        get
        {
            return Cards;
        }
    }

    static Deck()
    {
        Cards.AddRange(new List<Card>() {
        new Card("Lucky Charm", Protect),
        new Card("Good Attitude", GiveFood),
        new Card("Weak Ground", NerfEnemies),
        new Card("Lucky Charm", AllowMoveEnemy),

        new Card("Land II", Feel.Grassland, 2),
        new Card("Land II", Feel.Ruins, 2),
        new Card("Land II", Feel.Marsh, 2),
        new Card("Land II", Feel.Mountain, 2),

        new Card("Land III", Feel.Grassland, 3),
        new Card("Land III", Feel.Ruins, 3),
        new Card("Land III", Feel.Marsh, 3),
        new Card("Land III", Feel.Mountain, 3),

        new Card("Land IV", Feel.Grassland, 4),
        new Card("Land IV", Feel.Ruins, 4),
        new Card("Land IV", Feel.Marsh, 4),
        new Card("Land IV", Feel.Mountain, 4),

        new Card("Land V", Feel.Mountain, 5), // 2x
        new Card("Land V", Feel.Mountain, 5), // 2x
        new Card("Dungeons", AddLootAndEnemies),
        new Card("City", AddEnemyProtection),

        new Card("Smoothen Terrain", AllowClearWalls), // 4x
        new Card("Smoothen Terrain", AllowClearWalls), // 4x
        new Card("Smoothen Terrain", AllowClearWalls), // 4x
        new Card("Smoothen Terrain", AllowClearWalls), // 4x

        new Card("Minor Earthquake", AllowTwist), // 4x
        new Card("Minor Earthquake", AllowTwist), // 4x
        new Card("Minor Earthquake", AllowTwist), // 4x
        new Card("Minor Earthquake", AllowTwist), // 4x

        new Card("Fresh Thoughts", Draw2), // 4x
        new Card("Fresh Thoughts", Draw2), // 4x
        new Card("Fresh Thoughts", Draw2), // 4x
        new Card("Fresh Thoughts", Draw2), // 4x

        new Card("Rejuvination", Restock9Lands), // 4x
        new Card("Rejuvination", Restock9Lands), // 4x
        new Card("Rejuvination", Restock9Lands), // 4x
        new Card("Rejuvination", Restock9Lands), // 4x

        new Card("Major Earthquake", Allow3Twist), // 4x
        new Card("Major Earthquake", Allow3Twist), // 4x
        new Card("Major Earthquake", Allow3Twist), // 4x
        new Card("Major Earthquake", Allow3Twist), // 4x

        new Card("Free Dungeon", SetNextLandWithLoot, Feel.Ruins, 1, true), // 4x
        new Card("Bountiful Harvest", SetNextLandWithLoot, Feel.Grassland, 1, true), // 4x
        new Card("Special Marsh", SetNextLandWithLoot, Feel.Marsh, 1, true), // 4x
        new Card("Gold Mine", SetNextLandWithLoot, Feel.Mountain, 1, true), // 4x

        new Card("Angry Gods", Improve2Enemies), // 4x
        new Card("Angry Gods", Improve2Enemies), // 4x
        new Card("Angry Gods", Improve2Enemies), // 4x
        new Card("Angry Gods", Improve2Enemies), // 4x

        new Card("Nemesis", SpawnBoss), // 4x
        new Card("Nemesis", SpawnBoss), // 4x
        new Card("Nemesis", SpawnBoss), // 4x
        new Card("Nemesis", SpawnBoss) // 4x
    });
    }

    /// Function definitions
    /// 
    private static void Protect()
    {

    }

    private static void GiveFood()
    {

    }

    private static void NerfEnemies()
    {

    }

    private static void AllowMoveEnemy()
    {

    }

    private static void AllowClearWalls()
    {

    }

    private static void AllowTwist()
    {
        // add 1 to twist counter
    }

    private static void Allow3Twist()
    {
        AllowTwist();
        AllowTwist();
        AllowTwist();
    }

    private static void Improve2Enemies()
    {
        // Spawn until 2

        // improve 2 random
    }

    private static void SpawnBoss()
    {

    }

    private static void SetNextLandWithLoot()
    {

    }

    private static void Restock9Lands()
    {

    }

    private static void Draw2()
    {

    }

    private static void AddLootAndEnemies()
    {

    }

    private static void AddEnemyProtection()
    {

    }

}
