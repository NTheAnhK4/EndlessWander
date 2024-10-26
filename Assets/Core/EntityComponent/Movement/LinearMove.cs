using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : ChildBehavior, IAutoMove
{
    public void Move(Transform entity, float speed)
    {
        entity.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
