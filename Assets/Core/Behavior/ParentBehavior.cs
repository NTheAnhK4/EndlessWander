
using System;
using UnityEngine;

public class ParentBehavior : MonoBehaviour
{
    protected virtual void LoadComponent(){
        LoadExternalComponent();
        LoadComponentInChild();
        LoadComponentInIt();
    }

    protected virtual void LoadExternalComponent()
    {
        
    }

    protected virtual void LoadComponentInChild()
    {
        
    }

    protected virtual void LoadComponentInIt()
    {
        
    }

    protected virtual void ResetValue()
    {
        
    }

    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }

    protected virtual void OnEnable()
    {
        LoadComponent();
        ResetValue();
    }
}
