using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string name;
    public int lands;
    public Effect effect;
    public bool mustForcePlay;

    public Card(string name, int lands, Effect effect, bool mustForcePlay)
    {
        this.name = name;
        this.lands = lands;
        this.effect = effect;
        this.mustForcePlay = mustForcePlay;
    }

    public bool ForcePlay()
    {
        return ActivateEffect();
    }

    public bool ActivateEffect()
    {
        return effect.Activate();
    }
}
