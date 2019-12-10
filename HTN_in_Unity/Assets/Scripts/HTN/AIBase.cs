using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentOperatorStatus
{
    Continue,
    Success,
    Failed
}

public abstract class AIBase : MonoBehaviour
{
    protected PlanRunner planRunner;

    // 継承先で具体を代入
    protected IWorldState worldState;
    protected TaskBase rootTask;


    void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdate();
    }

    /// <summary>
    /// Awake時に1度だけ呼ばれる
    /// Domainの初期化処理をする予定
    /// </summary>
    protected virtual void OnAwake() { }

    /// <summary>
    /// Start時に1度だけ呼ばれる
    /// </summary>
    protected virtual void OnStart()
    {
        planRunner = new PlanRunner(this, rootTask);
        planRunner.UpdatePlan(worldState);
    }

    /// <summary>
    /// Update時に呼ばれる
    /// </summary>
    protected virtual void OnUpdate()
    {
        //planRunner.UpdatePlan(worldState);
    }

    /// <summary>
    /// PrimitiveTaskがOperatorを追加したいときに呼ぶ
    /// </summary>
    public void AddOperator(IOperator op)
    {
        planRunner.AddOperator(op);
    }
}
