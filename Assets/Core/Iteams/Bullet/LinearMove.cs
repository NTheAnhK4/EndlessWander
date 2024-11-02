
using UnityEngine;

public class LinearMove : ChildBehavior,IMove
{
    [SerializeField] protected Transform entity;
    [SerializeField] protected float speed = 5f;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        entity ??= transform.parent;
    }

    protected void Moving(Transform target)
    {
        target.Translate(Vector3.right * (speed * Time.deltaTime));
    }

    private void Update()
    {
        Moving(entity);
    }
}
