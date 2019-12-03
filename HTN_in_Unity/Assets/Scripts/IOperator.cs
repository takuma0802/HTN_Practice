using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOperator
{
    void Execute(WorldState state);
}

public abstract class Operator : MonoBehaviour
{
    public abstract void Execute(WorldState state);
}