using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExampleDomain
{
    private static ExampleDomain instance = new ExampleDomain();
    public static ExampleDomain Instance
    {
        get { return instance; }
    }

    private static Dictionary<DefinedTaskEnum, TaskBase> TaskRepository;
    private static Dictionary<DefinedMethodEnum, Method> MethodRepository;
    private static Dictionary<DefinedPreConditionEnum, PreConditionBase> PreConditionRepository;


    public void Initialize()
    {
        TaskRepository = new Dictionary<DefinedTaskEnum, TaskBase>();
        MethodRepository = new Dictionary<DefinedMethodEnum, Method>();
        PreConditionRepository = new Dictionary<DefinedPreConditionEnum, PreConditionBase>();
    }

    private object CreateInstance(string typeName)
    {
        Type type = Type.GetType(typeName);
        return Activator.CreateInstance(type);
    }

    private void AddTask(DefinedTaskEnum taskEnum)
    {
        TaskBase instance = (TaskBase)CreateInstance(taskEnum.ToString());
        TaskRepository[taskEnum] = instance;
    }

    private void AddMethod(DefinedMethodEnum methodEnum)
    {
        Method instance = (Method)CreateInstance(methodEnum.ToString());
        MethodRepository[methodEnum] = instance;
    }

    private void AddPreCondition(DefinedPreConditionEnum preConditionEnum)
    {
        PreConditionBase instance = (PreConditionBase)CreateInstance(preConditionEnum.ToString());
        PreConditionRepository[preConditionEnum] = instance;
    }

    public TaskBase GetTask(DefinedTaskEnum taskEnum)
    {
        if (!TaskRepository.ContainsKey(taskEnum))
        {
            AddTask(taskEnum);
        }
        return TaskRepository[taskEnum];
    }

    public Method GetMethod(DefinedMethodEnum methodEnum)
    {
        if (!MethodRepository.ContainsKey(methodEnum))
        {
            AddMethod(methodEnum);
        }
        return MethodRepository[methodEnum];
    }

    public PreConditionBase GetPreCondition(DefinedPreConditionEnum preConditionEnum)
    {
        if (!PreConditionRepository.ContainsKey(preConditionEnum))
        {
            AddPreCondition(preConditionEnum);
        }
        return PreConditionRepository[preConditionEnum];
    }
}

public enum DefinedTaskEnum
{
    PrepareMeatTask,
    EatMeatTask,
    MoveToTask,
}

public enum DefinedMethodEnum
{
    PrepareMeatMethod1,
    PrepareMeatMethod2
}

public enum DefinedPreConditionEnum
{
    EatMeatPreCondition
}