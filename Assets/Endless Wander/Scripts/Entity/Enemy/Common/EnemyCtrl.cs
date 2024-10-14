using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ParentBehavior
{
    /// <summary>
    /// used to control enemy
    /// no script in child allow to connect with this script
    /// </summary>
    [SerializeField] protected EnemyLinks enemyLinks;
    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        this.LoadLinks();
    }

    protected virtual void LoadLinks()
    {
        if (enemyLinks != null) return;
        enemyLinks = transform.GetComponent<EnemyLinks>();
        Debug.Log(transform.name + " Load Links successful");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        enemyLinks.StateMachine.ChangeAction(enemyLinks.MovementBase);
    }

    public virtual void ChangeMovement()
    {
        enemyLinks.StateMachine.ChangeAction(enemyLinks.MovementBase);
        enemyLinks.AnimMachine.ChangeAnim("Move");
    }

    public virtual void ChangeIdle()
    {
        enemyLinks.StateMachine.ChangeAction(null);
        enemyLinks.AnimMachine.ChangeAnim("Idle");
    }

    public virtual void ChangeAttack()
    {
        enemyLinks.StateMachine.ChangeAction(enemyLinks.AttackBase);
    }
    protected virtual void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.I)) ChangeIdle();
        if(Input.GetKeyDown(KeyCode.A)) ChangeAttack();
        if(Input.GetKeyDown(KeyCode.M)) ChangeMovement();
        enemyLinks.StateMachine.UpdateState();
    }
}
