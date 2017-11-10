using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    public List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    // bij start moet deze list worden gepopuleerd met kaarten uit het deck
}
