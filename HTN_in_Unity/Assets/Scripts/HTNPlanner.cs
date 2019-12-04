using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTNPlanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var aa = new MoveToTask();
        var ii = aa.GetaOperator(new WorldState());
        var uu = gameObject.AddComponent(ii);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
