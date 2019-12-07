using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatTask : PrimitiveTask<PlayerWorldState>
{
    public EatMeatTask() : base()
    {
    }

    public override bool IsSatisfiedPreConditions(PlayerWorldState currentState)
    {
        return currentState.MeatNumber > 0;
    }

    public override IWorldState ApplyEffectsToWorldState(PlayerWorldState previousState)
    {
        previousState.MeatNumber--;
        return previousState;
    }

    // public override Operator GetOperator(PlayerWorldState previousState)
    // {
    //     return new EatMeatOperator();
    // }
}