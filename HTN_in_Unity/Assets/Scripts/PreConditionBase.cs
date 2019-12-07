using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PreConditionBase
{
    public abstract bool CheckPreCondition(IWorldState state);
}

public abstract class PreConditionBase<T> : PreConditionBase where T : IWorldState
{
    public override bool CheckPreCondition(IWorldState state)
    {
        return CheckPreCondition((T)state);
    }

    public abstract bool CheckPreCondition(T state);

}
