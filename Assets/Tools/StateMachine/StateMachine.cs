using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : ChildBehavior
{
    [SerializeField] protected ActionBase curAction;
    

    public virtual void ChangeAction(ActionBase newAction)
    {
        if(curAction != null) curAction.ExitAction();
        curAction = newAction;
        if(curAction != null) curAction.EnterAction();
    }

    public virtual void UpdateState()
    {
        if(curAction != null) curAction.UpdateAction();
    }
}
