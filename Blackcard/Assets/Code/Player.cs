﻿using Assets.Code.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int magicalMight = 10;
    public int physicalMight = 10;
    public int life = 5;
    public int food = 15;
    public Deck deck;
    public Hand hand;
    private GameObject player;

    public Player(GameObject playerinstance)
    {
        deck = new Deck();
        hand = new Hand();
        player = playerinstance;
    }

    public void MovePlayer(Land planetomoveto)
    {
        if (CheckMove(planetomoveto))
        {
            Gamemanager.instance.PlayerMoved(planetomoveto);
            if (planetomoveto.HasEnemy)
            {
                if (!planetomoveto.enemy.Fight(this.physicalMight, this.magicalMight))
                {
                    life--;
                    return;
                }
                else
                {
                    Loot l = planetomoveto.enemy.Loot();
                    this.food += l.Food;
                    this.physicalMight += l.PhysicalMight;
                    this.magicalMight += l.MagicalMight;
                    planetomoveto.enemy.Kill();
                    planetomoveto.CleanEnemy();
                }
            }
            if (planetomoveto.HasLoot)
            {
                this.food += planetomoveto.loot.Food;
                this.physicalMight += planetomoveto.loot.PhysicalMight;
                this.magicalMight += planetomoveto.loot.MagicalMight;
                planetomoveto.CleanLoot();
            }
            player.transform.position = new Vector3(planetomoveto.transform.position.x, planetomoveto.transform.position.y, -1);
        }
    }

    public bool CanMove(int moves)
    {
        Vector2 currentplayerlocation = new Vector2(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.y));

        Land up;
        Land down;
        Land left;
        Land right;
        Fieldmanager.instance.lands.TryGetValue(new Vector2(currentplayerlocation.x, currentplayerlocation.y + 1), out up);
        Fieldmanager.instance.lands.TryGetValue(new Vector2(currentplayerlocation.x, currentplayerlocation.y - 1), out down);
        Fieldmanager.instance.lands.TryGetValue(new Vector2(currentplayerlocation.x - 1, currentplayerlocation.y), out left);
        Fieldmanager.instance.lands.TryGetValue(new Vector2(currentplayerlocation.x + 1, currentplayerlocation.y), out right);

        if (up != null && up.feel.movement_cost <= moves) return true;
        if (down != null && down.feel.movement_cost <= moves) return true;
        if (left != null && left.feel.movement_cost <= moves) return true;
        if (right != null && right.feel.movement_cost <= moves) return true;
        return false;

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
