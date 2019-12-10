using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillMeatTask : PrimitiveTask<ExampleWorldState>
{
    public GrillMeatTask() : base()
    {
        TaskType = TaskType.PrimitiveTask;
        TaskName = "肉を焼く";
    }

    public override bool IsSatisfiedPreConditions(ExampleWorldState currentState)
    {
        return currentState.RawMeat > 0
            && currentState.IsHasPan;
    }

    public override IWorldState ApplyEffectsToWorldState(ExampleWorldState previousState)
    {
        var state = (ExampleWorldState)previousState.Clone();
        state.GrilledMeat++;
        state.RawMeat--;
        return state;
    }

    public override bool Execute(ExampleWorldState state)
    {
        state.GrilledMeat++;
        state.RawMeat--;
        Log.Instance.Printlog(TaskType.ToString() + TaskName);
        return true;
    }
}
