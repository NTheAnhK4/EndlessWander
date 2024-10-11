
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    protected override Vector3 GetHorizontal()
    {
        return InputManager.Instance.GetVertical();
    }

    protected override Vector3 GetVertical()
    {
        return InputManager.Instance.GetHorizontal();
    }

    protected override void ResetValue()
    {
        entity = transform.parent.parent;
        speed = 5f;
    }
}
