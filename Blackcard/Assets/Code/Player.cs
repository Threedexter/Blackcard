using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int magicalMight;
    public int physicalMight;
    public int life;
    public int food;
    public Deck deck;
    public Hand hand;
    private GameObject player;

    public Player(GameObject playerinstance)
    {
        player = playerinstance;
    }

    public void MovePlayer(Land planetomoveto)
    {
       if (CheckMove(planetomoveto))
       {
           player.transform.position = planetomoveto.transform.position;
       }
    }

    public bool CheckMove(Land moveto)
    {
        Vector2 currentplayerlocation = new Vector2(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y));

        Land currentland = GetCurrentLand(currentplayerlocation);

        if (moveto.transform.position.x > currentplayerlocation.x)
        {
            return (moveto.walls.leftBlocked || currentland.walls.rightBlocked) ? false : true;
        }
        else if (moveto.transform.position.x < currentplayerlocation.x)
        {
            return (moveto.walls.rightBlocked || currentland.walls.leftBlocked) ? false : true;
        }
        else if (moveto.transform.position.y > currentplayerlocation.y)
        {
            return (moveto.walls.bottomBlocked || currentland.walls.topBlocked) ? false : true;
        }
        else if (moveto.transform.position.y > currentplayerlocation.y)
        {
            return (moveto.walls.topBlocked || currentland.walls.bottomBlocked) ? false : true;
        }
        return false;
    }

    public Land GetCurrentLand(Vector2 currentlocation)
    {
        Land currentland = null;

        Fieldmanager.instance.lands.TryGetValue(currentlocation, out currentland);

        return currentland;
    }
}
