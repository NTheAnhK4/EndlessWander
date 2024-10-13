using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singeton<InputManager>
{
   

    public Vector3 GetHorizontal()
    {
        return Input.GetAxis("Horizontal") * Vector3.right;
    }

    public Vector3 GetVertical()
    {
        return Input.GetAxis("Vertical") * Vector3.up;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoolingManager.Instance.Spawn("Enemies", "Enemy1", Vector3.zero);
        }
    }
}
