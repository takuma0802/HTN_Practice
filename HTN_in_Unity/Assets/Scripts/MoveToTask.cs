﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTask : PrimitiveTask
{
    private Vector3 targetPos;
    public MoveToTask() : base()
    {
        taskName = "MoveTo";
    }

    public override bool IsSatisfiedPreConditions(WorldState currentState)
    {
        return currentState.MeatNumber > 0;
    }

    public override WorldState ApplyEffectsToWorldState(WorldState previousState)
    {
        return previousState;
    }
}