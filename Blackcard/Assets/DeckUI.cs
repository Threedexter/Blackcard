using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{

    public static DeckUI instance;

    public List<Text> cards;

    private Player newPlayer
    {
        get
        {
            return Gamemanager.instance.player;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        DisplayCards(newPlayer);
    }

    public void DisplayCards(Player player)
    {
        if (player.hand == null || player.hand.cards == null || player == null) return;

        for (int i = 0; i < this.cards.Count; i++)
        {
            if (this.cards[i] != null)
            {
                this.cards[i].text = "";
            }
        }

        for (int i = 0; i < player.hand.cards.Count; i++)
        {
            if (i < cards.Count)
            {
                if (this.cards[i] != null)
                {
                    cards[i].text = player.hand.cards[i].name + System.Environment.NewLine + player.hand.cards[i].description;
                }
            }
        }
    }

    public void SelectCard(int cardIndex)
    {
        if (newPlayer.hand.cards.Count <= cardIndex) return;
        Gamemanager.instance.ActivateCard(newPlayer.hand.cards[cardIndex]);
    }
}
