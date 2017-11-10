using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string name;
    public int lands;
    public Action effect;
    public string description;
    public Feel feel;
    public bool mustForcePlay;

    public Card(string name, string description, Action effect, Feel feel = null, int lands = 0, bool mustForcePlay = false)
    {
        this.name = name;
        this.lands = lands;
        this.effect = effect;
        this.mustForcePlay = mustForcePlay;
        this.feel = feel;
    }

    public Card(string name, string description, Feel feel, int lands = 0, bool mustForcePlay = false)
    {
        this.name = name;
        this.lands = lands;
        this.mustForcePlay = mustForcePlay;
        this.feel = feel;
    }

    public bool ForcePlay()
    {
        return ActivateEffect();
    }

    public bool ActivateEffect()
    {
        if (effect == null) return false;
        effect();
        return true;
    }
}
