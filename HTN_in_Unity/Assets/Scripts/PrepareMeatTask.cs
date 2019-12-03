using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareMeatTask : CompoundTask
{
    public PrepareMeatTask() : base()
    {
        taskName = "PrepareMeat";
        Methods.Add(new PrepareMeatMethod1());
    }

    public override Method FindSatisfiedMethod(WorldState currentState)
    {
        foreach (var method in Methods)
        {
            if (method.IsSatisfiedPreConditions(currentState))
            {
                return method;
            }
        }
        return null;
    }

    public class PrepareMeatMethod1 : Method
    {
        public PrepareMeatMethod1()
        {
            SubTasks = new List<ITask>();
            SubTasks.Add(new EatMeatTask());
            SubTasks.Add(new MoveToTask());
        }

        public override bool IsSatisfiedPreConditions(WorldState currentState)
        {
            return currentState.MeatNumber > 0;
        }
    }
}