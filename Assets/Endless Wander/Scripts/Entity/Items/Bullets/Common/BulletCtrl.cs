
using UnityEngine;

public class BulletCtrl : ParentBehavior
{
    [SerializeField] protected BulletLinks bulletLinks;
    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        this.LoadLinks();
    }

    protected virtual void LoadLinks()
    {
        if (bulletLinks != null) return;
        bulletLinks = transform.GetComponent<BulletLinks>();
        Debug.Log(transform.name + " Load Links successful");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        bulletLinks.StateMachine.ChangeAction(bulletLinks.MovementBase);
    }

    protected virtual void Update()
    {
        bulletLinks.StateMachine.UpdateState();
    }
}
