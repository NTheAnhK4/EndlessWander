
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletHit : ChildBehavior
{
    [SerializeField] protected BoxCollider2D _boxCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected float damage = 1f;
    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        (_boxCollider2D = LoadComponent<BoxCollider2D>(_boxCollider2D)).isTrigger = true;
        (_rigidbody2D = LoadComponent<Rigidbody2D>(_rigidbody2D)).isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<EntityReceiver>()?.TakeDamage(damage);
    }
}
