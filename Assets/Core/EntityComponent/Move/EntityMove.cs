
using MBT;
using UnityEngine;
using System;

public class EntityMove : EntityComponent
{
    public enum MoveStatus
    {
        TargetedMove,
        RetreatedMove,
        AutomatedMove,
        Stop
    }

    [SerializeField] protected EntityEnergy energy;
    [SerializeField] protected Transform entity;
    [SerializeField] protected Transform target;
    [SerializeField] protected TargetedMove targetedMove;
    [SerializeField] protected RetreatedMove retreatedMove;
    [SerializeField] protected MoveStatus curMove;
    [SerializeField] protected float speed = 2f;
    private Vector3 direction = Vector3.right;

    public Transform Target
    {
        get => target;
        set => target = value;
    }
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        targetedMove = LoadComponent<TargetedMove>(targetedMove, "Targeted Move");
        retreatedMove = LoadComponent<RetreatedMove>(retreatedMove, "Retreated Move");
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        entity ??= dataRelay.transform;
        energy = dataRelay.GetEntityComponent<EntityEnergy>(eCompID.Energy);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        curMove = MoveStatus.AutomatedMove;
    }

    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.Move,this);
    }

    protected void Move(Action moveAction)
    {
        if (!energy.CanUseEnergy(1f)) return;
        energy.UseEnergy(Time.deltaTime);
        moveAction.Invoke();
    }

    protected void TargetedMove()
    {
        Move(() => targetedMove.Moving(entity, target, speed));
    }

    protected void RetreatedMove()
    {
        Move(() => retreatedMove.Moving(entity, target, speed));
    }

    protected void AutomatedMove()
    {
        Move(() => 
        {
            if (entity.position.x > 20) direction = Vector3.left;
            else if (entity.position.x < -20) direction = Vector3.right;

            entity.transform.Translate(direction * speed * Time.deltaTime);
        });
    }
    protected void Stop()
    {
        energy.RecoverEnergy(Time.deltaTime);
    }
    public void ChangeMoveStatus(MoveStatus newMoveStatus)
    {
        curMove = newMoveStatus;
    }

    public void SetStopMove(FunctionCallerNode functionCallerNode)
    {
        ChangeMoveStatus(MoveStatus.Stop);
        functionCallerNode.Result = NodeResult.success;
    }

    public void SetTargetedMove(Transform _target)
    {
        Target = _target;
        ChangeMoveStatus(MoveStatus.TargetedMove);
    }

    protected void Update()
    {
        if(curMove == MoveStatus.AutomatedMove) AutomatedMove();
        else if(curMove == MoveStatus.TargetedMove) TargetedMove();
        else  if(curMove == MoveStatus.RetreatedMove) RetreatedMove();
        else Stop();
    }
}
