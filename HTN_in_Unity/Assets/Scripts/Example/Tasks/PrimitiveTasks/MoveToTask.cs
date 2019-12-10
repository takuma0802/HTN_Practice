using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTask : PrimitiveTask<ExampleWorldState>
{
    public MoveToTask() : base()
    {
        TaskType = TaskType.PrimitiveTask;
        TaskName = "移動する";
    }

    public override bool IsSatisfiedPreConditions(ExampleWorldState currentState)
    {
        return currentState.MoveTarget != null;
    }

    public override IWorldState ApplyEffectsToWorldState(ExampleWorldState previousState)
    {
        var state = (ExampleWorldState)previousState.Clone();
        state.MoveTarget = null;
        return state;
    }

    public override bool Execute(ExampleWorldState state)
    {
        Log.Instance.Printlog(TaskType.ToString() + TaskName + "to" + state.MoveTarget);
        state.MoveTarget = null;
        return true;
    }
}
