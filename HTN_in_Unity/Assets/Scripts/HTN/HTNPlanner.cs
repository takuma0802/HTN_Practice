using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HTNPlanner
{
    public class PlannerState
    {
        public IWorldState WorkingWS;
        public List<TaskBase> FinalPlanList;
        public List<TaskBase> TaskListToProcess;
        public int NextMethodNumber;

        public PlannerState(IWorldState workingWS, List<TaskBase> finalPlanList, List<TaskBase> taskListToProcess, int nextMethodNumber)
        {
            this.WorkingWS = workingWS;
            this.FinalPlanList = finalPlanList;
            this.TaskListToProcess = taskListToProcess;
            this.NextMethodNumber = nextMethodNumber;
        }
    }


    private PlannerState plannerState;
    private List<PlannerState> plannerStateHistory = new List<PlannerState>();

    public HTNPlanner()
    {
    }

    public List<TaskBase> Planning(IWorldState currentState, TaskBase rootTask)
    {
        plannerStateHistory.Clear();
        plannerState = new PlannerState(
            currentState.Clone(),
            new List<TaskBase>(),
            new List<TaskBase>() { rootTask },
            0);

        while (plannerState.TaskListToProcess.Count > 0)
        {
            var currentTask = plannerState.TaskListToProcess[0];
            Debug.Log("CurrentTask:" + currentTask);
            if (currentTask is CompoundTask currentCompoundTask)
            {
                var satisfiedMethod = FindSatisfiedMethod(currentCompoundTask, plannerState);
                if (satisfiedMethod != null)
                {
                    RecordDecompositionOfTask(currentCompoundTask);
                    plannerState.TaskListToProcess.RemoveAt(0);
                    plannerState.TaskListToProcess.InsertRange(0, satisfiedMethod.SubTasks);
                }
                else
                {
                    RestoreToLastDecomposedTask();
                }
            }
            else // PrimitiveTask
            {
                if (currentTask.CheckPreCondition(plannerState.WorkingWS))
                {
                    plannerState.TaskListToProcess.RemoveAt(0);
                    plannerState.FinalPlanList.Add(currentTask);
                    plannerState.WorkingWS = currentTask.ApplyEffects(plannerState.WorkingWS);
                }
                else
                {
                    RestoreToLastDecomposedTask();
                }
            }
        }

        return new List<TaskBase>(plannerState.FinalPlanList);
    }

    /// <summary>
    /// CompoundTaskが保有しているMethodの中から、現在のWorldStateに合致するMethodを返す。
    /// なければ、nullを返す。
    /// </summary>
    private Method FindSatisfiedMethod(CompoundTask currentCompoundTask, PlannerState plannerState)
    {
        var methodsWorldState = plannerState.WorkingWS.Clone();
        var methods = currentCompoundTask.Methods;
        while (plannerState.NextMethodNumber < methods.Count)
        {
            var method = methods[plannerState.NextMethodNumber];
            plannerState.NextMethodNumber++;

            if (method.CheckPreCondition(methodsWorldState))
            {
                return method;
            }
        }

        return null;
    }

    /// <summary>
    /// 直前のCompoundTaskの状態まで遡れるように、現在のPlannerStateを記録
    /// </summary>
    private void RecordDecompositionOfTask(CompoundTask nextCompoundTask)
    {
        var copyOfPlannerState = new PlannerState(
            plannerState.WorkingWS.Clone(),
            new List<TaskBase>(plannerState.FinalPlanList),
            new List<TaskBase>(plannerState.TaskListToProcess),
            plannerState.NextMethodNumber);

        copyOfPlannerState.TaskListToProcess.Add(nextCompoundTask);
        plannerStateHistory.Add(copyOfPlannerState);
    }

    private void RestoreToLastDecomposedTask()
    {
        // これ以上過去のPlannerStateに遡れない場合、Planningを終了させる
        if (plannerStateHistory.Count == 0)
        {
            plannerState.TaskListToProcess.Clear();
            return;
        }

        plannerState = plannerStateHistory.Last();
        plannerStateHistory.RemoveAt(plannerStateHistory.Count - 1);
    }
}