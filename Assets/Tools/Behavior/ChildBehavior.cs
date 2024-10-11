

using UnityEngine;

public class ChildBehavior : MonoBehaviour
{
    /// <summary>
    /// only call after parent scripts are called
    /// </summary>
    protected virtual void LoadComponent()
    {
        // Load for data
        LoadComponentInParent();
        //Load for scripts and tranfer data
        LoadComponentInChild();
    }

    protected virtual void ResetValue()
    {
        
    }
    protected virtual void LoadComponentInParent()
    {
        
    }

    protected virtual void LoadComponentInChild()
    {
        
    }

    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }

    protected virtual void Start()
    {
        LoadComponent();
    }
}
