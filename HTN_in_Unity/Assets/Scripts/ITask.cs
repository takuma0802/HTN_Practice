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
    TaskType TaskType { get; }

}
