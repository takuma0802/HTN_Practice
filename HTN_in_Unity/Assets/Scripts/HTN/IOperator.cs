using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOperator
{
    void Execute(IWorldState state);
}

public abstract class Operator : MonoBehaviour
{
    public abstract void Execute(IWorldState state);
}