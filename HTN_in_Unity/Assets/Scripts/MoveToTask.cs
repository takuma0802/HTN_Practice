using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTask : PrimitiveTask<PlayerWorldState>
{
    private Vector3 targetPos;
    public MoveToTask() : base()
    {
    }

    public override bool IsSatisfiedPreConditions(PlayerWorldState currentState)
    {
        return true;
    }

    public override IWorldState ApplyEffectsToWorldState(PlayerWorldState previousState)
    {
        previousState.MeatNumber++;
        return previousState;
    }

    // public override Operator GetOperator(PlayerWorldState currentState)
    // {
    //     return new MoveToOperator(currentState.FocusOfAttention.transform.position);
    // }
}
