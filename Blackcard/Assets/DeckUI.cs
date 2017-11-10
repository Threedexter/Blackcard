using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour {

    public Text[] cards;

    private Player newPlayer;

    // Use this for initialization
    void Start () {
        newPlayer = new Player();
        newPlayer.hand = new Hand();
        List<Card> testCards = new List<Card>();
        testCards.Add(new Card("Test1", 2, new Effect(), true));
        testCards.Add(new Card("Test2", 2, new Effect(), true));
        testCards.Add(new Card("Test3", 2, new Effect(), true));
        testCards.Add(new Card("Test4", 2, new Effect(), true));
        testCards.Add(new Card("Test5", 2, new Effect(), true));
        testCards.Add(new Card("Test6", 2, new Effect(), true));
        testCards.Add(new Card("Test7", 2, new Effect(), true));
        testCards.Add(new Card("Test8", 2, new Effect(), true));
        newPlayer.hand.cards = testCards;
        
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
