using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLettuceTask : PrimitiveTask<ExampleWorldState>
{
    public CutLettuceTask() : base()
    {
        TaskType = TaskType.PrimitiveTask;
        TaskName = "レタスを切る";
    }

    public override bool IsSatisfiedPreConditions(ExampleWorldState currentState)
    {
        return currentState.Lettuce > 0
            && currentState.IsHasCuttingBoard;
    }

    public override IWorldState ApplyEffectsToWorldState(ExampleWorldState previousState)
    {
        var state = (ExampleWorldState)previousState.Clone();
        state.CutLettuce++;
        state.Lettuce--;
        return state;
    }

    public override bool Execute(ExampleWorldState state)
    {
        state.CutLettuce++;
        state.Lettuce--;
        Log.Instance.Printlog(TaskType.ToString() + TaskName);
        return true;
    }
}
