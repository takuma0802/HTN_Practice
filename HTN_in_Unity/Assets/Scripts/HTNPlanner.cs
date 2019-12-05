using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public interface IPlanner
{
    List<PrimitiveTask> ReturnPlanList(WorldState currentState);
    void SetDefaultRootTask(ITask defaultTask);
}

public class PlannerBase<T> : IPlanner where T : AIBase
{
    protected T _owner;
    protected List<PrimitiveTask> finalPlanList = new List<PrimitiveTask>();
    protected List<ITask> taskListToProcess = new List<ITask>();
    protected List<CompoundTask> compoundTaskHistory = new List<CompoundTask>();
    protected ITask defaultRootTask;

    public PlannerBase(T owner)
    {
        _owner = owner;
    }

    public List<PrimitiveTask> ReturnPlanList(WorldState currentState)
    {
        finalPlanList.Clear();
        compoundTaskHistory.Clear();
        taskListToProcess.Clear();

        // 仮
        taskListToProcess.Add(defaultRootTask);

        var worldState = currentState;
        return ReturnPlanList_internal(worldState);
    }

    protected List<PrimitiveTask> ReturnPlanList_internal(WorldState virtualWS)
    {
        while (taskListToProcess.Count > 0)
        {
            if (taskListToProcess[0].TaskType == TaskType.PrimitiveTask)
            {
                var nextTask = taskListToProcess[0] as PrimitiveTask;
                var isSatisfied = nextTask.IsSatisfiedPreConditions(virtualWS);
                if (isSatisfied)
                {
                    virtualWS = FoundSatisfiedPrimitiveTask(nextTask, virtualWS);
                }
                else
                {
                    RestoreToLastDecomposedTask();
                }
            }
            else if (taskListToProcess[0].TaskType == TaskType.CompoundTask)
            {
                var nextTask = taskListToProcess[0] as CompoundTask;
                var satisfiedMethod = nextTask.FindSatisfiedMethod(virtualWS);
                if (satisfiedMethod != null)
                {
                    FoundSatisfiedCompoundTask(nextTask, satisfiedMethod);
                }
                else
                {
                    RestoreToLastDecomposedTask();
                }
            }
        }
        return finalPlanList;
    }

    protected WorldState FoundSatisfiedPrimitiveTask(PrimitiveTask task, WorldState virtualWS)
    {
        taskListToProcess.RemoveAt(0);
        finalPlanList.Add(task);
        virtualWS = task.ApplyEffectsToWorldState(virtualWS);
        return virtualWS;
    }

    protected void FoundSatisfiedCompoundTask(CompoundTask task, Method satisfiedMethod)
    {
        taskListToProcess.RemoveAt(0);
        taskListToProcess.InsertRange(0, satisfiedMethod.SubTasks);
        RecordDecompositionOfTask(task);
    }


    protected void RecordDecompositionOfTask(CompoundTask nextTask)
    {
        compoundTaskHistory.Add(nextTask);
    }

    protected void RestoreToLastDecomposedTask()
    {
        compoundTaskHistory.RemoveAt(compoundTaskHistory.Count - 1);
        taskListToProcess.Insert(0, compoundTaskHistory.LastOrDefault());
    }

    public virtual void SetDefaultRootTask(ITask defaultTask)
    {

    }
}