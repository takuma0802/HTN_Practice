using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType
{
    PrimitiveTask,
    CompoundTask
}

public abstract class TaskBase
{
    public TaskType TaskType { get; set;}
    public string TaskName { get; set;}
    public virtual bool CheckPreCondition(IWorldState state) { return true; }
    public virtual IWorldState ApplyEffects(IWorldState state) { return state.Clone(); }
    public virtual bool ExecuteOperator(IWorldState state) { return true; }
}
