using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatTask : PrimitiveTask<ExampleWorldState>
{
    public EatMeatTask() : base()
    {
        TaskType = TaskType.PrimitiveTask;
        TaskName = "移動する";
    }

    public override bool IsSatisfiedPreConditions(ExampleWorldState currentState)
    {
        //return currentState.RawMeat > 0;
        return true;
    }

    public override IWorldState ApplyEffectsToWorldState(ExampleWorldState previousState)
    {
        //previousState.RawMeat--;
        return previousState;
    }

    public override bool Execute(ExampleWorldState state)
    {
        return true;
    }
}