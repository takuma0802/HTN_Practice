using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType
{
    PrimitiveTask,
    CompoundTask
}

public interface ITask
{
    string TaskName { get; }
    TaskType TaskType { get; }
}
