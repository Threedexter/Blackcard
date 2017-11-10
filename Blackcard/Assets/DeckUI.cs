using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour {

    public Text[] cards;

    private Player newPlayer
    {
        get
        {
            return Gamemanager.instance.player;
        }
    }
	
	// Update is called once per frame
	void Update () {
        DisplayCards(newPlayer);
	}

    public void DisplayCards(Player player)
    {
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].text = "";
        }

        for (int i = 0; i < player.hand.cards.Count; i++)
        {
            if(i < cards.Length)
            {
                cards[i].text = player.hand.cards[i].name + System.Environment.NewLine + player.hand.cards[i].effect.ToString();
            }
        }
    }

    public void SelectCard(int cardIndex)
    {
        Debug.Log(newPlayer.hand.cards[cardIndex].name);
    }
}
