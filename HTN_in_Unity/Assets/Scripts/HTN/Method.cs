using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Method
{
    public List<TaskBase> SubTasks = new List<TaskBase>();
    public List<PreConditionBase> PreConditions = new List<PreConditionBase>();

    public bool CheckPreCondition(IWorldState state)
    {
        foreach(var preCondition in PreConditions)
        {
            if(!preCondition.CheckPreCondition(state))
            {
                return false;
            }
        }
        return true;
    }
}