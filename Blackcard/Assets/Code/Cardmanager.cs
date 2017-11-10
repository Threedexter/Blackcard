using Assets.Code.Base;
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
        if (Deck.Cards.Count <= 0) return;
        for (int i = 0; i < drawcount; i++)
        {
            Card card = player.deck.cards.PickRandom();
            if (card != null)
            {
                player.hand.cards.Add(card);
                player.deck.cards.Remove(card);
            }
        }
    }

    public void DrawCards(Player player)
    {
        DrawCards(player, 1);
    }

    public void CheckEndTurnCards(Player player)
    {
        if (player.hand.cards.Count > 8)
        {
            player.hand.cards.RemoveAt(player.hand.cards.Count - 1);
        }
    }
}
