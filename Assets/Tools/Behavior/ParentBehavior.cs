using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBehavior : MonoBehaviour
{
    protected virtual void LoadComponentInChild()
    {
        
    }

    protected virtual void ResetValue()
    {
        
    }

    protected virtual void LoadExternalComponent()
    {
        
    }

    protected virtual void LoadComponentInIt()
    {
        
    }

    protected virtual void LoadComponent()
    {
        LoadExternalComponent();
        LoadComponentInChild();
        LoadComponentInIt();
    }

    protected virtual void OnEnable()
    {
        LoadComponent();
    }

    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }
}
