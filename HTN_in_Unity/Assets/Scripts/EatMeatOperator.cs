using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatOperator : Operator
{
    public override void Execute(WorldState state)
    {
        Debug.Log("Eat Meat!");
    }
}
