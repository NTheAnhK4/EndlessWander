using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEye : EntityEye
{
    protected override void ResetValue()
    {
        base.ResetValue();
        vision = 3f;
    }
}
