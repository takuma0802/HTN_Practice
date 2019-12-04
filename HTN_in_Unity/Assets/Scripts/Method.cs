using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Method
{
    protected List<ITask> subTasks;
    public List<ITask> SubTasks { get { return subTasks; } }
    public abstract bool IsSatisfiedPreConditions(WorldState currentState);
}