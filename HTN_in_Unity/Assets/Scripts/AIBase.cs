using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBase : MonoBehaviour
{
    protected IPlanner planner;
    protected WorldState worldState;
    protected List<PrimitiveTask> currentPlan;
    protected PrimitiveTask currentTask;


    void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {

    }

    void Update()
    {
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }
}
