using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatOperator : Operator
{

    public EatMeatOperator(){ }
    public override void Execute(IWorldState state)
    {
        Debug.Log("Eat Meat!");
    }
}
