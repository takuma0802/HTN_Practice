using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PrimitiveTask<T> : TaskBase where T : IWorldState
{
    protected TaskType taskType;
    public TaskType TaskType { get { return taskType; } }

    public PrimitiveTask()
    {
        taskType = TaskType.PrimitiveTask;
    }

    // 自分のタスクを実行できるかどうかを返す
    public override bool CheckPreCondition(IWorldState state) { return IsSatisfiedPreConditions((T)state); }
    public abstract bool IsSatisfiedPreConditions(T currentState);

    // タスクを実行した結果、変更されたWorldStateを返す
    public override IWorldState ApplyEffects(IWorldState state) { return ApplyEffectsToWorldState((T)state); }
    public abstract IWorldState ApplyEffectsToWorldState(T previousState);

    //public abstract Operator GetOperator(T previousState);
}
