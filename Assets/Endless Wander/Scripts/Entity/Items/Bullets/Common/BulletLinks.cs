using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLinks : ParentBehavior
{
    [SerializeField] protected MovementBase movementBase;
    [SerializeField] protected StateMachine stateMachine;

    public StateMachine StateMachine => stateMachine;

    public MovementBase MovementBase => movementBase;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        LoadMovement();
        LoadStateMachine();
    }

    protected virtual void LoadMovement()
    {
        if (movementBase != null) return;
        movementBase = transform.GetComponentInChildren<MovementBase>();
        Debug.Log(transform.name + " Load Movement successful");
    }

    protected virtual void LoadStateMachine()
    {
        if (stateMachine != null) return;
        stateMachine = transform.GetComponentInChildren<StateMachine>();
        Debug.Log(transform.name + " Load StateMachine successful");
    }
}
