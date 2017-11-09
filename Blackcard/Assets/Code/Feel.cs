using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Feel
{
    public readonly static Feel Grassland;
    public readonly static Feel Marsh;
    public readonly static Feel Mountain;
    public readonly static Feel Ruins;
    public readonly static Feel Start;

    static Feel ()
    {
        Start = new Feel()
        {
            spawn_enemy_chance = 0,
            movement_cost = 1,
            spawn_loot_chance = 0,
            min_blocked = 0,
            max_blocked = 0
        };
        Grassland = new Feel()
        {
            spawn_enemy_chance = 60,
            movement_cost = 1,
            spawn_loot_chance = 10,
            min_blocked = 0,
            max_blocked = 2
        };
        Marsh = new Feel()
        {
            spawn_enemy_chance = 30,
            movement_cost = 2,
            spawn_loot_chance = 10,
            min_blocked = 1,
            max_blocked = 2
        };
        Mountain = new Feel()
        {
            spawn_enemy_chance = 30,
            movement_cost = 3,
            spawn_loot_chance = 10,
            min_blocked = 1,
            max_blocked = 3
        };
        Ruins = new Feel()
        {
            spawn_enemy_chance = 30,
            movement_cost = 2,
            spawn_loot_chance = 30,
            min_blocked = 1,
            max_blocked = 4
        };
    }

    public int spawn_enemy_chance;
    public int spawn_loot_chance;
    public int blocked_sides;
    public int movement_cost;
    private int min_blocked;
    private int max_blocked;

    private Feel()
    {
    }

    public void GenerateWalls()
    {
        blocked_sides = Random.Range(min_blocked, max_blocked + 1);
    }