
using UnityEngine;

public class ChildBehavior : MonoBehaviour
{
    protected virtual void ResetValue()
    {
        
    }

    protected virtual void LoadComponentInParent()
    {
        
    }

    protected virtual void LoadComponentInIt()
    {
        
    }

    protected virtual void LoadComponentInChild()
    {
        
    }

    protected virtual void LoadComponent()
    {
        LoadComponentInParent();
        LoadComponentInIt();
        LoadComponentInChild();
    }

    protected void Reset()
    {
        LoadComponent();
        ResetValue();
    }

    protected virtual void Start()
    {
        LoadComponent();
        ResetValue();
    }
}
