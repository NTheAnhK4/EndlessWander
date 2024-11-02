
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityReceiver : EntityComponent
{
    [SerializeField] protected EntityHealth entityHealth;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Rigidbody2D rb;
    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        (boxCollider2D = LoadComponent<BoxCollider2D>(boxCollider2D)).isTrigger = true;
        (rb = LoadComponent<Rigidbody2D>(rb)).isKinematic = true;
    }

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        entityHealth = LoadComponent<EntityHealth>(entityHealth, "Health");
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("i'm take" + damage);
    }
}
