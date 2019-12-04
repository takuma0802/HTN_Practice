using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PrimitiveTask : ITask
{
    protected string taskName;
    public string TaskName { get { return taskName; } }

    protected TaskType taskType;
    public TaskType TaskType { get { return taskType; } }

    public PrimitiveTask()
    {
        taskType = TaskType.PrimitiveTask;
    }

    // 自分のタスクを実行できるかどうかを返す
    public abstract bool IsSatisfiedPreConditions(WorldState currentState);

    // タスクを実行した結果、変更されたWorldStateを返す
    public abstract WorldState ApplyEffectsToWorldState(WorldState previousState);
    public abstract Operator GetOperator(WorldState previousState);
}
