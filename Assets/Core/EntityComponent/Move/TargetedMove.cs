using UnityEngine;
public class TargetedMove : ChildBehavior
{
    /// <summary>
    /// use AStartFinding in the future
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    public void Moving(Transform entity, Transform target, float speed)
    {
        Vector3 direction = (target.position - entity.position).normalized;
        entity.transform.Translate(direction * speed * Time.deltaTime);
    }
}
