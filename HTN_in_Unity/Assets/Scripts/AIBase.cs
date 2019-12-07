using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBase : MonoBehaviour
{
    protected HTNPlanner planner;
    protected IWorldState worldState;
    protected List<TaskBase> currentPlan;
    protected TaskBase currentTask;
    [SerializeField] protected TaskBase defaultTask;


    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        //OnUpdate();
    }

    /// <summary>
    /// Awake時に1度だけ呼ばれる
    /// </summary>
    protected virtual void Initialize()
    {
        defaultTask = new PrepareMeatTask();
        worldState = new PlayerWorldState(this);
        planner = new HTNPlanner(this, defaultTask);
        OnUpdate();
    }

    /// <summary>
    /// Update時に呼ばれる
    /// </summary>
    protected virtual void OnUpdate()
    {
        currentPlan = planner.Planning(worldState);

        foreach(var plan in currentPlan)
        {
            Debug.Log(plan);
        }
    }
}
