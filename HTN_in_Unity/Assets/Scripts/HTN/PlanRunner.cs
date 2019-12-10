using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum CurrentTaskStatus
{
    NoPlan,
    PlanContinue,
    PlanComplete,
    PlanFailed
}

public class PlanRunner
{
    private AIBase owner;
    private TaskBase rootTask;

    private HTNPlanner planner = new HTNPlanner();
    private List<TaskBase> currentPlan = null;
    private TaskBase currentTask = null;

    // OperatorListはMonoBehaviourを必要とするTaskや時間がかかるものを保有し、実行する(予定)
    protected List<IOperator> operatorList = new List<IOperator>();
    protected IOperator currentOperator = null;

    public PlanRunner(AIBase owner, TaskBase rootTask)
    {
        this.owner = owner;
        this.rootTask = rootTask;
    }

    /// <summary>
    /// Planの管理を行う
    /// </summary>
    /// <param name="currentState"></param>
    public void UpdatePlan(IWorldState currentState)
    {
        // Operatorの実行
        // まだ実行中の場合は何もしない
        var operatorStatus = UpdateCurrentOperator(currentState);
        if (operatorStatus == CurrentOperatorStatus.Continue)
        {
            return;
        }

        // Taskが終了したので、PlanとTaskの更新
        // まだPlanがある場合は何もしない
        var planStatus = UpdateCurrentPlanStatus(currentState);
        if (planStatus == CurrentTaskStatus.PlanContinue)
        {
            return;
        }

        // プランニング
        currentPlan = planner.Planning(currentState, rootTask);
        UpdateCurrentPlanStatus(currentState);
    }

    /// <summary>
    /// 登録されているOperatorの実行、監視を行う
    /// </summary>
    private CurrentOperatorStatus UpdateCurrentOperator(IWorldState worldState)
    {
        if (operatorList.Count == 0)
        {
            return CurrentOperatorStatus.Success;
        }

        // Operatorの実行処理（まだ作れてない）
        // return CurrentOperatorStatus.Continue;
        operatorList[0].Execute(worldState);
        return CurrentOperatorStatus.Success;
    }

    /// <summary>
    /// 現在のCurrentTaskを実行し、次のTaskがあれば更新する。
    /// その上で、現在のPlanの状態を返す。
    /// </summary>
    private CurrentTaskStatus UpdateCurrentPlanStatus(IWorldState worldState)
    {
        // Taskの実行
        if (currentTask != null)
        {
            if (!currentTask.CheckPreCondition(worldState))
            {
                currentTask = null;
                currentPlan = null;
                return CurrentTaskStatus.PlanFailed;
            }

            if (!currentTask.ExecuteOperator(worldState))
            {
                currentTask = null;
                currentPlan = null;
                return CurrentTaskStatus.PlanFailed;
            }

            worldState = currentTask.ApplyEffects(worldState);
            currentTask = null;
        }

        if (currentPlan == null)
        {
            return CurrentTaskStatus.NoPlan;
        }

        if (currentTask == null && currentPlan.Count == 0)
        {
            return CurrentTaskStatus.PlanComplete;
        }

        currentTask = currentPlan[0];
        return CurrentTaskStatus.PlanContinue;
    }

    public void AddOperator(IOperator op)
    {
        operatorList.Add(op);
    }
}