
using System.Collections.Generic;
using MBT;
using UnityEngine;

public class EntitySensor : EntityComponent
{
    
    protected readonly EntityClassifier entityClassifier = new EntityClassifier();
    protected EntityDetection entityDetection;
    [SerializeField] protected float radius = 5f;
    [SerializeField] protected Transform entity;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected List<Transform> sensedObjects;
    public TransformReference playerStored = new TransformReference(VarRefMode.DisableConstant);
    
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadEntity();
    }

    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        this.LoadCollider();
        entityDetection = new EntityDetection(entity, radius, boxCollider2D);

    }
    protected void LoadCollider()
    {
        if (boxCollider2D != null) return;
        boxCollider2D = transform.parent.GetComponentInChildren<BoxCollider2D>();
    }

    protected void LoadEntity()
    {
        if (entity != null) return;
        entity = dataRelay.transform;
    }
    
    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.Sensor,this);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        radius = 15f;
    }
    protected void DetectObjects()
    {
        entityClassifier.ResetCount();
        sensedObjects = entityDetection.DetectObjects();
        entityClassifier.ClassifyDetectedObjects(sensedObjects);
        
    }
    
    void OnDrawGizmos()
    {
        // Thiết lập màu sắc cho vòng tròn
        Gizmos.color = Color.red; // Màu đỏ

        // Vẽ vòng tròn xung quanh vị trí của đối tượng
        Gizmos.DrawWireSphere(entity.position, radius);
    }

    
    public void IsPlayerVisible(FunctionCallerNode functionCallerNode)
    {
        Transform player = entityClassifier.player;
        playerStored.Value = player;
        if (player == null)
        {
            functionCallerNode.Result = NodeResult.failure;
            return;
        }
        functionCallerNode.Result = NodeResult.success;
    }
    protected void Update()
    {
        DetectObjects();
    }
}
