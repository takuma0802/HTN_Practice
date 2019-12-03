using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Method
{
    public IList<ITask> SubTasks;
    public abstract bool IsSatisfiedPreConditions(WorldState currentState);
}