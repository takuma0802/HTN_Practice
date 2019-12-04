using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrepareMeatTask : CompoundTask
{
    public PrepareMeatTask() : base()
    {
        taskName = "PrepareMeat";
        Methods.Add(new PrepareMeatMethod1());
    }

    public override Method FindSatisfiedMethod(WorldState currentState)
    {
        var satisfiedMethod = Methods.FirstOrDefault((method => method.IsSatisfiedPreConditions(currentState)));

        return satisfiedMethod;
    }

    public class PrepareMeatMethod1 : Method
    {
        public PrepareMeatMethod1()
        {
            subTasks = new List<ITask>();
            subTasks.Add(new EatMeatTask());
            subTasks.Add(new MoveToTask());
        }

        public override bool IsSatisfiedPreConditions(WorldState currentState)
        {
            return currentState.MeatNumber > 0;
        }
    }
}