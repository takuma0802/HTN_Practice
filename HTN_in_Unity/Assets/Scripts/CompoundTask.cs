using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompoundTask : ITask
{
    protected string taskName;
    public string TaskName { get { return taskName; } }

    protected TaskType taskType;
    public TaskType TaskType { get { return taskType; } }

    public IList<Method> Methods;

    public CompoundTask()
    {
        taskType = TaskType.CompoundTask;
    }

    // 保有しているMethodの中から、現在のWorldStateに合致するMethodを返す
    // なければ、nullを返す
    public abstract Method FindSatisfiedMethod(WorldState currentState);
}