using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int magicalMight = 10;
    public int physicalMight = 10;
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
            Gamemanager.instance.PlayerMoved(planetomoveto);
        }
    }

    public bool CheckMove(Land moveto)
    {
        if (Gamemanager.instance.moveSteps - moveto.feel.movement_cost < 0) return false;

        Vector2 currentplayerlocation = new Vector2(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y));

        Land currentland = GetCurrentLand(currentplayerlocation);

        float xDistance = Mathf.Round(moveto.transform.position.x - currentland.transform.position.x);
        float yDistance = Mathf.Round(moveto.transform.position.y - currentland.transform.position.y);
        bool withinRangeX = xDistance < 1.1f && xDistance > -1.1f;
        bool withinRangeY = yDistance < 1.1f && yDistance > -1.1f;
        if (!withinRangeX || !withinRangeY) return false;
        if (Mathf.Round(currentplayerlocation.x) != Mathf.Round(moveto.transform.position.x) &&
            Mathf.Round(currentplayerlocation.y) != Mathf.Round(moveto.transform.position.y)) return false;

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
        else if (moveto.transform.position.y < currentplayerlocation.y)
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
