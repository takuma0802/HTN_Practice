using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatTask : PrimitiveTask
{
    public EatMeatTask() : base()
    {
        taskName = "EatMeat";
    }

    public override bool IsSatisfiedPreConditions(WorldState currentState)
    {
        return currentState.MeatNumber > 0;
    }

    public override WorldState ApplyEffectsToWorldState(WorldState previousState)
    {
        return previousState;
    }

    public override Operator GetOperator(WorldState previousState)
    {
        return new EatMeatOperator();
    }
}