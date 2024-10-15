
using UnityEngine;


public class EntityNerve : ParentBehavior, INerve
{
    /// <summary>
    /// used to transfer signal
    /// </summary>
    [SerializeField] protected EntityBrain brain;
    [SerializeField] protected EntityHandCtrl handCtrl;
    [SerializeField] protected EntityBody body;
    [SerializeField] protected EntityLegCtrl legCtrl;
    [SerializeField] protected EntityEye eyes;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadBrain();
        this.LoadHands();
        this.LoadBody();
        this.LoadLegs();
        this.LoadEye();
    }

    protected virtual void LoadBrain()
    {
        if(brain != null) return;
        brain = transform.GetComponentInChildren<EntityBrain>();
        if(brain != null) 
            Debug.Log(transform.name + " Load brain successufl");
    }

    protected virtual void LoadHands()
    {
        if (handCtrl != null) return;
        handCtrl = transform.GetComponentInChildren<EntityHandCtrl>();
        if(handCtrl != null)
            Debug.Log(transform.name + " Load hands successful");
    }

    protected virtual void LoadBody()
    {
        if (body != null) return;
        body = transform.GetComponentInChildren<EntityBody>();
        if(body != null)
            Debug.Log(transform + " Load body successful");
    }

    protected virtual void LoadLegs()
    {
        if(legCtrl != null) return;
        legCtrl = transform.GetComponentInChildren<EntityLegCtrl>();
        if(legCtrl != null) 
            Debug.Log(transform.name + " Load legs successful");
    }

    protected virtual void LoadEye()
    {
        if(eyes != null) return;
        eyes = transform.GetComponentInChildren<EntityEye>();
        if(eyes != null)
            Debug.Log(transform.name + "Load eyes successful");
    }

    public virtual void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }

   

}
