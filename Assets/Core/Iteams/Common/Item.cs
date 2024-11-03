using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ChildBehavior
{
    public abstract void Execute(object value = null);
    public abstract bool CanUse(object param = null);
}
