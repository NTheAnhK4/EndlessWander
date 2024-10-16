using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singeton<T> : ParentBehavior where T : ParentBehavior
{
    private static T instance;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only one " + typeof(T) + " allow to exist");
            
        }

        instance = (T) (ParentBehavior) this;
    }
}
