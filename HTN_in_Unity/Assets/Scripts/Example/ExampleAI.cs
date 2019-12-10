using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAI : AIBase
{
    protected override void OnAwake()
    {
        base.OnAwake();
        ExampleDomain.Instance.Initialize();
    }

    protected override void OnStart()
    {
        rootTask = ExampleDomain.Instance.GetTask(DefinedTaskEnum.PrepareMeatTask);
        worldState = new ExampleWorldState(this);
        base.OnStart();
    }
}
