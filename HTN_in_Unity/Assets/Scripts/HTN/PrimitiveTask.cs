using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PrimitiveTask<T> : TaskBase where T : IWorldState
{

    // タスクを実行できるかどうかを返す
    public override bool CheckPreCondition(IWorldState state) { return IsSatisfiedPreConditions((T)state); }
    public abstract bool IsSatisfiedPreConditions(T currentState);

    // タスクを実行した場合のWorldStateを返す
    public override IWorldState ApplyEffects(IWorldState state) { return ApplyEffectsToWorldState((T)state); }
    public abstract IWorldState ApplyEffectsToWorldState(T previousState);

    // タスクを実行する
    public override bool ExecuteOperator(IWorldState state) { return Execute((T)state); }
    public abstract bool Execute(T state);
}
