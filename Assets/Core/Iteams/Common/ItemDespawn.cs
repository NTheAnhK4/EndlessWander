

public abstract class ItemDespawn : ChildBehavior
{
    protected abstract bool CanDespawn();

    public void Despawn()
    {
        PoolingManager.Despawn(transform.parent.gameObject);
    }

    protected void Update()
    {
        if (!CanDespawn()) return;
        Despawn();
    }
}
