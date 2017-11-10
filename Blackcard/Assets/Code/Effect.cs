using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    public int duration;
    public string description = "This is the standard description of a effect";

    public bool Activate()
    {
        return false;
    }

    public override string ToString()
    {
        return description;
    }
}
