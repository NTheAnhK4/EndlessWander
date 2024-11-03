
using UnityEngine;

public class ItemDespawnByDistance : ItemDespawn
{
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float curDis;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (mainCam != null) return;
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

    }

    protected override bool CanDespawn()
    {
        curDis = Vector2.Distance(mainCam.transform.position, transform.parent.position);
        return curDis > disLimit;
    }
}
