using Assets.Code.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        new Card("Lucky Charm", "Protect 5 lands", Protect),
        new Card("Good Attitude", "Give stock for another 5 turns", GiveFood),
        new Card("Weak Ground","Weaken all enemies", NerfEnemies),
        new Card("Shinies","Move an enemy", AllowMoveEnemy),

        new Card("Land II","Lay 2 grasslands", Feel.Grassland, 2),
        new Card("Land II","Lay 2 ruins", Feel.Ruins, 2),
        new Card("Land II","Lay 2 marshes", Feel.Marsh, 2),
        new Card("Land II","Lay 2 mountains", Feel.Mountain, 2),

        new Card("Land III","Lay 3 grasslands", Feel.Grassland, 3),
        new Card("Land III","Lay 3 ruins", Feel.Ruins, 3),
        new Card("Land III","Lay 3 marshes", Feel.Marsh, 3),
        new Card("Land III","Lay 3 mountains", Feel.Mountain, 3),

        new Card("Land IV","Lay 4 grasslands", Feel.Grassland, 4),
        new Card("Land IV","Lay 4 ruins", Feel.Ruins, 4),
        new Card("Land IV","Lay 4 marshes", Feel.Marsh, 4),
        new Card("Land IV","Lay 4 mountains", Feel.Mountain, 4),

        new Card("Mountain Range","Lay 5 mountains", Feel.Mountain, 5), // 2x
        new Card("Mountain Range","Lay 5 mountains", Feel.Mountain, 5), // 2x
        new Card("Dungeons", "Add two lands with loot and enemies", AddLootAndEnemies),
        new Card("City", "Protects a land from enemies", AddEnemyProtection),

        //new Card("Smoothen Terrain", "Removes all walls from a land", AllowClearWalls), // 4x
        //new Card("Smoothen Terrain", "Removes all walls from a land", AllowClearWalls), // 4x
        //new Card("Smoothen Terrain", "Removes all walls from a land", AllowClearWalls), // 4x
        //new Card("Smoothen Terrain", "Removes all walls from a land", AllowClearWalls), // 4x

        //new Card("Minor Earthquake", "Twist a land", AllowTwist), // 4x
        //new Card("Minor Earthquake", "Twist a land", AllowTwist), // 4x
        //new Card("Minor Earthquake", "Twist a land", AllowTwist), // 4x
        //new Card("Minor Earthquake", "Twist a land", AllowTwist), // 4x

        new Card("Fresh Thoughts", "Draw 2 cards", Draw2), // 4x
        new Card("Fresh Thoughts", "Draw 2 cards", Draw2), // 4x
        new Card("Fresh Thoughts", "Draw 2 cards", Draw2), // 4x
        new Card("Fresh Thoughts", "Draw 2 cards", Draw2), // 4x

        new Card("Rejuvination", "Reshuffle 9 lands", Restock9Lands), // 4x
        new Card("Rejuvination", "Reshuffle 9 lands", Restock9Lands), // 4x
        new Card("Rejuvination", "Reshuffle 9 lands", Restock9Lands), // 4x
        new Card("Rejuvination", "Reshuffle 9 lands", Restock9Lands), // 4x

        //new Card("Major Earthquake", "Twist 3 lands", Allow3Twist), // 4x
        //new Card("Major Earthquake", "Twist 3 lands", Allow3Twist), // 4x
        //new Card("Major Earthquake", "Twist 3 lands", Allow3Twist), // 4x
        //new Card("Major Earthquake", "Twist 3 lands", Allow3Twist), // 4x

        new Card("Free Dungeon", "Add a land with loot", SetNextLandWithLoot, Feel.Ruins, 1, true), // 4x
        new Card("Bountiful Harvest", "Add a land with loot", SetNextLandWithLoot, Feel.Grassland, 1, true), // 4x
        new Card("Special Marsh", "Add a land with loot", SetNextLandWithLoot, Feel.Marsh, 1, true), // 4x
        new Card("Gold Mine", "Add a land with loot", SetNextLandWithLoot, Feel.Mountain, 1, true), // 4x

        new Card("Angry Gods", "Empower 2 enemies", Improve2Enemies), // 4x
        new Card("Angry Gods", "Empower 2 enemies", Improve2Enemies), // 4x
        new Card("Angry Gods", "Empower 2 enemies", Improve2Enemies), // 4x
        new Card("Angry Gods", "Empower 2 enemies", Improve2Enemies), // 4x

        new Card("Nemesis", "Spawn a boss", SpawnBoss), // 4x
        new Card("Nemesis", "Spawn a boss", SpawnBoss), // 4x
        new Card("Nemesis", "Spawn a boss", SpawnBoss), // 4x
        new Card("Nemesis", "Spawn a boss", SpawnBoss) // 4x
    });
    }

    /// Function definitions
    /// 
    private static void Protect()
    {
        var lands = Fieldmanager.instance.GetRandomUnprotectedLands(5);
        foreach (Land l in lands)
        {
            l.isProtected = true; // todo: add effect to unprotect them after 5 turns
        }
    }

    private static void GiveFood()
    {
        Gamemanager.instance.player.food += 5;
    }

    private static void NerfEnemies()
    {
        foreach(Enemy e in Enemy.AllEnemies)
        {
            e.Weaken(25);
        }
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
        var elist = Enemy.AllEnemies.PickRandom(2);
        foreach (Enemy e in elist)
        {
            e.Weaken(-25);
        }
    }

    private static void SpawnBoss()
    {
        Land land = Fieldmanager.instance.GetRandomLands(1).Single();
        land.SpawnEnemy(true);
    }

    private static void SetNextLandWithLoot()
    {
        // todo: set next land.
        Land land = Fieldmanager.instance.GetRandomLands(1).Single();
        land.SpawnLoot();

    }

    private static void Restock9Lands()
    {
        var lands = Fieldmanager.instance.GetRandomLands(9);
        foreach (Land l in lands)
        {
            l.SpawnEnemyIfShould(false);
            l.SpawnLootIfShould();
        }
    }

    private static void Draw2()
    {
        Cardmanager.Instance.DrawCards(Gamemanager.instance.player, 2);
    }

    private static void AddLootAndEnemies()
    {
        // Todo: replace with the next 2 lands
        var lands = Fieldmanager.instance.GetRandomLands(2);
        foreach (Land l in lands)
        {
            l.SpawnEnemyIfShould(false);
            l.SpawnLootIfShould();
        }
    }

    private static void AddEnemyProtection()
    {

        var lands = Fieldmanager.instance.GetRandomLands(2);
        foreach (Land l in lands)
        {
            l.spawnedEnemy = true;
        }
    }

    public override string ToString()
    {
        return this.cards.Count.ToString(); 
    }
}
