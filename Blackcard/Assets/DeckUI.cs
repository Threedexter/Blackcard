using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{

    public Text[] cards;

    private Player newPlayer
    {
        get
        {
            return Gamemanager.instance.player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCards(newPlayer);
    }

    public void DisplayCards(Player player)
    {
        if (player.hand == null || player.hand.cards == null) return;

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].text = "";
        }

        for (int i = 0; i < player.hand.cards.Count; i++)
        {
            if (i < cards.Length)
            {
                cards[i].text = player.hand.cards[i].name + System.Environment.NewLine + player.hand.cards[i].description;
            }
        }
    }

    public void SelectCard(int cardIndex)
    {
        if (newPlayer.hand.cards.Count <= cardIndex) return;

        Card card = newPlayer.hand.cards[cardIndex];
        if (card.ActivateEffect())
        {
            newPlayer.hand.cards.RemoveAt(cardIndex);
        }
        else if (card.feel != null && Gamemanager.instance.landsToPlace <= 0)
        {
            Gamemanager.instance.landsToPlace = card.lands;
            Gamemanager.instance.feel = card.feel;
            newPlayer.hand.cards.RemoveAt(cardIndex);
        }
    }
}
