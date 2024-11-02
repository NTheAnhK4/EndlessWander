using System.Collections;
using System.Collections.Generic;
using MBT;
using UnityEngine;

public class DataStore : EntityComponent
{
    public TransformReference entity = new TransformReference(VarRefMode.DisableConstant);
    public TransformReference player = new TransformReference(VarRefMode.DisableConstant);
    protected override void RegisterSignal()
    {
        dataRelay.RegisterSignal(eCompID.DataStore,this);
    }
}
