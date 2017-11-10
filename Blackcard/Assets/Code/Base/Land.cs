using Assets.Code.Base;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Land : Target
{
    public Feel feel;

    [SerializeField]
    public Walls walls;
    protected Effect effect;

    public bool HasLoot
    {
        get { return loot != null; }
    }
    public bool HasEnemy
    {
        get { return enemy != null; }
    }

    private bool spawnedEnemy;
    private Loot loot;

    private bool spawnedLoot;
    private Enemy enemy;

    /// <summary>
    /// Spawns a land
    /// </summary>
    /// <param name="location"></param>
    /// <param name="feel"></param>
    public void Spawn(Vector2 location, Feel feel, bool spawnBoss = false)
    {
        this.walls = new Walls();
        this.feel = feel;
        // Decide to spawn loot
        SpawnLootIfShould();

        // Decide to spawn enemy
        SpawnEnemyIfShould(spawnBoss);

        switch (feel.name)
        {
            case "Grass":
                this.GetComponent<Renderer>().material.mainTexture = Fieldmanager.instance.grassPlanes.PickRandom();
                break;
            case "Marsh":
                this.GetComponent<Renderer>().material.mainTexture = Fieldmanager.instance.marshPlanes.PickRandom();
                break;
            case "Mountain":
                this.GetComponent<Renderer>().material.mainTexture = Fieldmanager.instance.mountainPlanes.PickRandom();
                break;
            case "Ruins":
                this.GetComponent<Renderer>().material.mainTexture = Fieldmanager.instance.ruinsPlanes.PickRandom();
                break;
        }

        // Set walls based on feel
        int walls = feel.blocked_sides.Generated;
        List<string> positions = new List<string>() { "top", "bottom", "left", "right" };
        positions = positions.PickRandom(walls).ToList();

        if (positions.Contains("top"))
        {
            PlaceWall(new Vector3(0, .45f, 0), true);
            this.walls.topBlocked = true;
        }
        if (positions.Contains("bottom"))
        {
            PlaceWall(new Vector3(0, -.45f, 0), true);
            this.walls.bottomBlocked = true;
        }
        if (positions.Contains("left"))
        {
            PlaceWall(new Vector3(-.45f, 0, 0));
            this.walls.leftBlocked = true;
        }
        if (positions.Contains("right"))
        {
            PlaceWall(new Vector3(.45f, 0, 0));
            this.walls.rightBlocked = true;
        }
    }

    /// <summary>
    /// Reshuffles a land for enemies and loot
    /// </summary>
    public void Reshuffle()
    {
        SpawnEnemyIfShould(false);
        SpawnLootIfShould();
    }

    /// <summary>
    /// Spawns an enemy
    /// </summary>
    /// <returns></returns>
    public Enemy SpawnEnemy(bool isBoss)
    {
        Enemy spawn = Instantiate(Fieldmanager.instance.enemy, this.transform, true) as Enemy;
        spawn.transform.position = transform.position;
        double multiplier = 1;
        if (isBoss)
        {
            multiplier = 2.5;
        }

        Player x = Gamemanager.instance.player;

        int magical = (int)(feel.magicalMightEnemy.Generated / 100f * multiplier * x.magicalMight);
        int physical = (int)(feel.physicalMightEnemy.Generated / 100f * multiplier * x.physicalMight);
        spawn.Spawn(magical, physical, new Loot()
        {
            Food = 1,
            PhysicalMight = (int)(physical * 0.05f),
            MagicalMight = (int)(magical * 0.05f)
        });

        return spawn;
    }

    /// <summary>
    /// Spawns loot
    /// </summary>
    /// <returns></returns>
    public Loot SpawnLoot()
    {
        Loot spawn = Instantiate(Fieldmanager.instance.loot, this.transform, true) as Loot;
        spawn.transform.position = transform.position;

        spawn.Spawn(feel.physicalMightLoot.Generated, feel.magicalMightLoot.Generated, feel.turnLoot.Generated);

        return spawn;
    }

    /// <summary>
    /// Removes the loot from this land
    /// </summary>
    public void CleanLoot()
    {
        spawnedLoot = false;
        if (HasLoot)
        {
            Destroy(loot);
        }
        loot = null;
    }

    /// <summary>
    /// Removes the enemy from this land
    /// </summary>
    public void CleanEnemy()
    {
        spawnedEnemy = false;
        if (HasEnemy)
        {
            Destroy(enemy);
        }
        enemy = null;
    }

    /// <summary>
    /// Spawns an enemy on this tile if it should / was spawned before but was re-triggered
    /// </summary>
    public void SpawnEnemyIfShould(bool isboss)
    {
        bool shouldspawn = !spawnedEnemy && (Random.Range(0, 101) < feel.spawn_enemy_chance);
        if (shouldspawn || isboss)
        {
            this.enemy = SpawnEnemy(isboss);
            spawnedEnemy = true;
        }
    }

    /// <summary>
    /// Spawns loot on this tile if it should / was spawned before but was re-triggered
    /// </summary>
    public void SpawnLootIfShould()
    {
        bool shouldspawn = !spawnedLoot && (Random.Range(0, 101) < feel.spawn_loot_chance);
        if (shouldspawn)
        {
            this.loot = SpawnLoot();
            spawnedLoot = true;
        }
    }

    /// <summary>
    /// Destroys this land and the loot and the enemy on it
    /// </summary>
    public void Decay()
    {
        CleanEnemy();
        CleanLoot();
        Destroy(this);
    }

    /// <summary>
    /// Places a wall on a certain spot
    /// </summary>
    /// <param name="location"></param>
    /// <param name="rotate"></param>
    private void PlaceWall(Vector3 location, bool rotate = false)
    {
        GameObject spawnedWall = Instantiate(Fieldmanager.instance.wall, this.transform, true);
        if (rotate)
            spawnedWall.transform.Rotate(new Vector3(0, 0, 1), 90);
        spawnedWall.transform.SetParent(this.transform);
        spawnedWall.transform.position = transform.position + location;
    }

    /// <summary>
    /// Turns the land to the left or right
    /// </summary>
    /// <param name="left"></param>
    public void Turn(bool left)
    {
        walls.Turn(left);
        int turnage = (left ? 90 : -90);
        this.transform.Rotate(new Vector3(0, -1, 0), turnage);
    }

    /// <summary>
    /// Adds a status effect to a land
    /// </summary>
    /// <param name="effect"></param>
    public void AddEffect(Effect effect)
    {
        this.effect = effect;
    }
}

