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

    public virtual void UpdateAction()
    {
        UpdateLogic();
        UpdatePhysis();
    }

    public virtual void EnterAction()
    {
        
    }

    public virtual void ExitAction()
    {
        
    }
}
