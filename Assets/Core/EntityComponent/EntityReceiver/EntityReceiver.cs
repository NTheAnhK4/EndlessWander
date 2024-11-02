
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityReceiver : EntityComponent
{
    [SerializeField] protected IHealth entityHealth;
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
        entityHealth = GetComponentInChildren<IHealth>() ?? CreateHealthComponent();
    }
    private IHealth CreateHealthComponent()
    {
        GameObject child = AddChildTransform("Health");
        if (!transform.parent.CompareTag("Player"))
        {
            return child.AddComponent<EntityHealth>();
        }
        return child.AddComponent<PlayerHealth>();
    }
    public void TakeDamage(float damage)
    {
        entityHealth.TakeDamage(damage);
    }

    public void Heal(float amount)
    {
        var entityEnergy = dataRelay.GetEntityComponent<EntityEnergy>(eCompID.Energy);
        if (!entityEnergy.CanUseEnergy(2)) return;
        entityEnergy.UseEnergy(Time.deltaTime*2f);
        entityHealth.Heal(amount);
    }
}
