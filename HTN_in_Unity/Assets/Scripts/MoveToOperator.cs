using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOperator : Operator
{
    private Vector3 targetPos;

    public MoveToOperator(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }

    public override void Execute(WorldState state)
    {
        Debug.Log("Eat Meat!");
    }
}
