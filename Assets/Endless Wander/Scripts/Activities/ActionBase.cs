using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBase : ChildBehavior
{
    protected virtual void UpdateLogic()
    {
        
    }

    protected virtual void UpdatePhysis()
    {
        
    }

    protected virtual void Update()
    {
        UpdateLogic();
        UpdatePhysis();
    }
}
