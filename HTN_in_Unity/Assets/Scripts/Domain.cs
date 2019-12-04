using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domain
{
    private static Domain instance = new Domain();
    public static Domain Instance
    {
        get { return instance;}
    }

    public void Initialize()
    {

    }
}