using Assets.Code.Base;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Land : Target
{
    protected Feel feel;

    [SerializeField]
    protected Walls walls;
    protected Effect effect;

    // debug
    public bool hasEnemy;
    public bool hasLoot;

    public void Spawn(Vector2 location, Feel feel)
    {
        this.walls = new Walls();
        this.feel = feel;
        //todo: adjust land to feel

        //todo: decide to spawn loot


        //todo: decide to spawn enemy


        //todo: set walls based on feel
        feel.GenerateWalls();
        int walls = feel.blocked_sides;
        Debug.Log("Generating Walls: " + walls);
        List<string> positions = new List<string>() { "top", "bottom", "left", "right" };
        positions = positions.PickRandom(walls).ToList();

        if (positions.Contains("top"))
        {
            PlaceWall(new Vector3(0, .45f, 0), true);
            Debug.Log("Generating Top Wall");
            this.walls.topBlocked = true;
        }
        if (positions.Contains("bottom"))
        {
            PlaceWall(new Vector3(0, -.45f, 0), true);
            Debug.Log("Generating Bottom Wall");
            this.walls.bottomBlocked = true;
        }
        if (positions.Contains("left"))
        {
            PlaceWall(new Vector3(-.45f, 0, 0));
            Debug.Log("Generating Left Wall");
            this.walls.leftBlocked = true;
        }
        if (positions.Contains("right"))
        {
            PlaceWall(new Vector3(.45f, 0, 0));
            Debug.Log("Generating Right Wall");
            this.walls.rightBlocked = true;
        }
    }

    private void PlaceWall(Vector3 location, bool rotate = false)
    {
        GameObject spawnedWall = Instantiate(Fieldmanager.instance.wall, this.transform, true);
        if (rotate)
            spawnedWall.transform.Rotate(new Vector3(0, 0, 1), 90);
        spawnedWall.transform.SetParent(this.transform);
        spawnedWall.transform.position = transform.position + location;
    }

    public void Turn(bool left)
    {
        walls.Turn(left);
        int turnage = (left ? 90 : -90);
        this.transform.Rotate(new Vector3(0, -1, 0), turnage);
    }

    public void AddEffect(Effect effect)
    {
        this.effect = effect;
    }
}

