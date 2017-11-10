using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardmanager : MonoBehaviour 
{
    private static Cardmanager instance;

    public static Cardmanager Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }

    public void DrawCards(Player player, int drawcount)
    {
        for (int i = 0; i < drawcount; i++)
        {
            player.hand.cards.Add(player.deck.cards[0]);
            player.deck.cards.RemoveAt(0);
        }
    }

    public void DrawCards(Player player)
    {
        DrawCards(player, 2);
    }

    public void CheckEndTurnCards(Player player)
    {
        if (player.hand.cards.Count > 8)
        {
            player.hand.cards.RemoveAt(player.hand.cards.Count - 1);
        }
    }
}
