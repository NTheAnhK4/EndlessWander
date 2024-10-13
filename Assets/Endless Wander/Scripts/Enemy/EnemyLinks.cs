
using UnityEngine;

public class EnemyLinks : ParentBehavior
{
    /// <summary>
    /// used for hold links and data of object
    /// </summary>
    [SerializeField] protected StateMachine stateMachine;
    [SerializeField] protected MovementBase movementBase;
    [SerializeField] protected AttackBase attackBase;
    [SerializeField] protected AnimMachine animMachine;
    public StateMachine StateMachine => stateMachine;

    public MovementBase MovementBase => movementBase;

    public AttackBase AttackBase => attackBase;

    public AnimMachine AnimMachine => animMachine;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadMovement();
        this.LoadAttack();
        this.LoadStateMachine();
        this.LoadAnimMachine();
    }

    protected virtual void LoadMovement()
    {
        if (movementBase != null) return;
        movementBase = transform.GetComponentInChildren<MovementBase>();
        Debug.Log(transform.name  + " Load Movement successful");
    }

    protected virtual void LoadAttack()
    {
        if (attackBase != null) return;
        attackBase = transform.GetComponentInChildren<AttackBase>();
        Debug.Log(transform.name + " Load Attack successful");
    }

    protected virtual void LoadStateMachine()
    {
        if (stateMachine != null) return;
        stateMachine = transform.GetComponentInChildren<StateMachine>();
        Debug.Log(transform.name + " Load StateMachine succeful");
    }

    protected virtual void LoadAnimMachine()
    {
        if (animMachine != null) return;
        animMachine = transform.GetComponentInChildren<AnimMachine>();
        Debug.Log(transform.name + " Load AnimMachine successful");
    }
    
}
