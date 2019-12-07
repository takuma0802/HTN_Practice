using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeatPreCondition : PreConditionBase<PlayerWorldState>
{
    public override bool CheckPreCondition(PlayerWorldState state)
    {
        return state.MeatNumber > 0;
    }
}
