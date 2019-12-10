using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrepareMeatTask : CompoundTask
{
    public PrepareMeatTask() : base()
    {
        TaskType = TaskType.CompoundTask;
        TaskName = "肉の準備をする";

        Methods.Add(ExampleDomain.Instance.GetMethod(DefinedMethodEnum.PrepareMeatMethod1));
        Methods.Add(ExampleDomain.Instance.GetMethod(DefinedMethodEnum.PrepareMeatMethod2));
    }
}

public class PrepareMeatMethod1 : Method
{
    public PrepareMeatMethod1()
    {
        SubTasks.Add(ExampleDomain.Instance.GetTask(DefinedTaskEnum.EatMeatTask));
        SubTasks.Add(ExampleDomain.Instance.GetTask(DefinedTaskEnum.MoveToTask));

        PreConditions.Add(ExampleDomain.Instance.GetPreCondition(DefinedPreConditionEnum.EatMeatPreCondition));
    }
}

public class PrepareMeatMethod2 : Method
{
    public PrepareMeatMethod2()
    {
        SubTasks.Add(ExampleDomain.Instance.GetTask(DefinedTaskEnum.MoveToTask));
        SubTasks.Add(ExampleDomain.Instance.GetTask(DefinedTaskEnum.EatMeatTask));
    }
}