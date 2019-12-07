using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldState : IWorldState
{
    private AIBase owner;

    public PlayerWorldState(AIBase owner)
    {
        this.owner = owner;
    }

    public IWorldState Clone()
    {
        return new PlayerWorldState(owner);
    }

    public int MeatNumber;

    public GameObject FocusOfAttention;
}