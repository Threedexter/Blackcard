using Assets.Code.Base;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Land : Target
{
    protected Feel feel;

    [SerializeField]
    public Walls walls;
    protected Effect effect;

    private bool spawnedEnemy;
    private bool spawnedLoot;

    /// <summary>
    /// Spawns a land
    /// </summary>
    /// <param name="location"></param>
    /// <param name="feel"></param>
    public void Spawn(Vector2 location, Feel feel)
    {
        this.walls = new Walls();
        this.feel = feel;
        // Decide to spawn loot
        SpawnLootIfShould();

        // Decide to spawn enemy
        SpawnEnemyIfShould();

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
        feel.GenerateWalls();
        int walls = feel.blocked_sides;
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
    /// Spawns an enemy on this tile if it should / was spawned before but was re-triggered
    /// </summary>
    public void SpawnEnemyIfShould()
    {
        bool shouldspawn = !spawnedEnemy && (Random.Range(0, 101) < feel.spawn_enemy_chance);
        if (shouldspawn)
        {
            GameObject spawn = Instantiate(Fieldmanager.instance.enemy, this.transform, true);
            spawn.transform.position = transform.position;
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
            GameObject spawn = Instantiate(Fieldmanager.instance.loot, this.transform, true);
            spawn.transform.position = transform.position;
        }
    }

    /// <summary>
    /// Destroys this land
    /// </summary>
    public void Decay()
    {
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

