using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrepareMeatTask : CompoundTask
{
    public PrepareMeatTask() : base()
    {
        Methods.Add(new PrepareMeatMethod1());
        Methods.Add(new PrepareMeatMethod2());
    }

    public class PrepareMeatMethod1 : Method
    {
        public PrepareMeatMethod1()
        {
            SubTasks.Add(new EatMeatTask());
            SubTasks.Add(new MoveToTask());

            PreConditions.Add(new EatMeatPreCondition());
        }
    }

    public class PrepareMeatMethod2 : Method
    {
        public PrepareMeatMethod2()
        {
            SubTasks = new List<TaskBase>();
            SubTasks.Add(new MoveToTask());
            SubTasks.Add(new EatMeatTask());

            //PreConditions.Add(new EatMeatPreCondition());
        }
    }
}