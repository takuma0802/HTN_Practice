using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class CompoundTask : TaskBase
{
    public List<Method> Methods = new List<Method>();
}