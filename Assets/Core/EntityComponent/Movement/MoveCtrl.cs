
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

    [SerializeField] protected Transform entity;
    [SerializeField] protected MoveType curMove;
    public Transform target;
    protected List<IAutoMove> autoMoveList = new List<IAutoMove>();
    protected List<IRetreatMove> retreatMoveList = new List<IRetreatMove>();
    protected List<ITargetMove> targetMoveList = new List<ITargetMove>();
    

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadAutoMove();
        this.LoadRetreatMove();
        this.LoadTargetMove();
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

    protected override void ResetValue()
    {
        base.ResetValue();
        curMove = MoveType.AutomatedMove;
        entity = transform.parent;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) curMove = MoveType.AutomatedMove;
        if (Input.GetKeyDown(KeyCode.R)) curMove = MoveType.RetreatedMove;
        if (Input.GetKeyDown(KeyCode.T)) curMove = MoveType.TargetedMove;
        switch (curMove)
        {
            case MoveType.AutomatedMove:
                AutoMovement();
                break;
            case MoveType.RetreatedMove:
                RetreateMovement();
                break;
            case MoveType.TargetedMove :
                TargetMovement();
                break;
        }
    }
}
