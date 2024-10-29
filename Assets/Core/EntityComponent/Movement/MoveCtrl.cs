
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;

public class MoveCtrl : ChildBehavior
{
    protected enum MoveType
    {
        AutomatedMove,
        RetreatedMove,
        TargetedMove
    }

    [SerializeField] protected DataRelay dataRelay;
    [SerializeField] protected Transform entity;
    [SerializeField] protected MoveType curMove;
    public Transform target;
    protected readonly List<IAutoMove> autoMoveList = new List<IAutoMove>();
    protected readonly List<IRetreatMove> retreatMoveList = new List<IRetreatMove>();
    protected readonly List<ITargetMove> targetMoveList = new List<ITargetMove>();
    

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadAutoMove();
        this.LoadRetreatMove();
        this.LoadTargetMove();
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadDataRelay();
    }

    protected virtual void LoadAutoMove()
    {
        if (autoMoveList.Count != 0) return;
        autoMoveList.AddRange(GetComponentsInChildren<IAutoMove>());
    }

    protected virtual void LoadRetreatMove()
    {
        if (retreatMoveList.Count != 0) return;
        retreatMoveList.AddRange(GetComponentsInChildren<IRetreatMove>());
    }

    protected virtual void LoadTargetMove()
    {
        if (targetMoveList.Count != 0) return;
        targetMoveList.AddRange(GetComponentsInChildren<ITargetMove>());
    }

    protected virtual void LoadDataRelay()
    {
        if(dataRelay != null) return;
        dataRelay = transform.GetComponentInParent<DataRelay>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        curMove = MoveType.AutomatedMove;
        entity = transform.parent;
    }

    protected override void Start()
    {
        base.Start();
        ReceiveSignal();
    }

    protected virtual void ReceiveSignal()
    {
        dataRelay.ReceiveSignal(MoveActionID.Auto, () =>
        {
            ChangeAction(MoveType.AutomatedMove);
        });
        dataRelay.ReceiveSignal(MoveActionID.MoveTo, (object param) =>
        {
            target = (Transform)(param);
            ChangeAction(MoveType.TargetedMove);
        });
        dataRelay.ReceiveSignal(MoveActionID.Retreat, (object param) =>
        {
            target = (Transform)param;
            ChangeAction(MoveType.RetreatedMove);
        });
    }

    protected virtual void ChangeAction(MoveType newMoveType)
    {
        curMove = newMoveType;
    }

    protected virtual void AutoMovement()
    {
        
        int id = Random.Range(0, autoMoveList.Count);
        autoMoveList[id].Move(entity,2);
    }

    protected virtual void RetreateMovement()
    {
        int id = Random.Range(0, retreatMoveList.Count);
        retreatMoveList[id].Move(entity,target,2);
    }

    protected virtual void TargetMovement()
    {
        int id = Random.Range(0, targetMoveList.Count);
        targetMoveList[id].Move(entity,target,2);
    }

    protected virtual void Update()
    {
        if(curMove == MoveType.AutomatedMove) AutoMovement();
        if(curMove == MoveType.TargetedMove) TargetMovement();
        if(curMove == MoveType.RetreatedMove) RetreateMovement();
    }
}
