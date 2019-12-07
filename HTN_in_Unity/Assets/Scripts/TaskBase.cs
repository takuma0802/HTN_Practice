using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType
{
    PrimitiveTask,
    CompoundTask
}

// public interface TaskBase
// {
//     TaskType TaskType { get; }
//     bool CheckPreCondition(IWorldState state);
//     void ApplyEffects(IWorldState state);
//     bool Execute(IWorldState state);
//     bool Terminate(IWorldState state, bool success);
// }

public abstract class TaskBase
{
    //public TaskType TaskType { get; }
    public virtual bool CheckPreCondition(IWorldState state) { return true; }
    public virtual IWorldState ApplyEffects(IWorldState state) { return state.Clone();}
    public virtual bool Execute(IWorldState state) { return true; }
    public virtual bool Terminate(IWorldState state, bool success) { return true; }

    // public abstract bool CheckPreCondition(IWorldState state);
    // public abstract IWorldState ApplyEffects(IWorldState state);
    // public abstract bool Execute(IWorldState state);
    // public abstract bool Terminate(IWorldState state, bool success);
}
