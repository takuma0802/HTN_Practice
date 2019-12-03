using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOperator : Operator
{
    public Vector3 targetPos;
    public override void Execute(WorldState state)
    {
        Debug.Log("Eat Meat!");
    }
}
