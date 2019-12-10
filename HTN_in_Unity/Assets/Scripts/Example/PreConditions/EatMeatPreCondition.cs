using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatPreCondition : PreConditionBase<ExampleWorldState>
{
    public override bool CheckPreCondition(ExampleWorldState state)
    {
        return state.RawMeat > 0;
    }
}
