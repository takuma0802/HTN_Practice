using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState
{
    private AIBase owner;
    public WorldState(AIBase owner)
    {
        this.owner = owner;
    }

    public int MeatNumber
    {
        get { return MeatNumber; }
        set { MeatNumber = value; }
    }

    public GameObject FocusOfAttention;
}
