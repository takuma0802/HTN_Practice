using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class CompoundTask : ITask
{
    protected TaskType taskType;
    public TaskType TaskType { get { return taskType; } }

    public IList<Method> Methods;

    public CompoundTask()
    {
        taskType = TaskType.CompoundTask;
    }

    // 保有しているMethodの中から、現在のWorldStateに合致するMethodを返す
    // なければ、nullを返す
    public virtual Method FindSatisfiedMethod(WorldState currentState)
    {
        var satisfiedMethod = Methods.FirstOrDefault((method => method.IsSatisfiedPreConditions(currentState)));

        return satisfiedMethod;
    }
}