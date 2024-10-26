
using UnityEngine;

public class CurvedMove : ChildBehavior, IRetreatMove, ITargetMove
{
    [SerializeField] protected float curveHeight = 2f;
    [SerializeField] protected float distanceTravelled = 0f;
    public void Move(Transform entity, Transform target, float speed)
    {
        float moveDistance = speed * Time.deltaTime;
        distanceTravelled += moveDistance;
        var position = target.position;
        float distance = Vector3.Distance(position , transform.position);
        float t = Mathf.Clamp01(distanceTravelled / distance);
       
        Vector3 startPosition = entity.position;
        Vector3 targetPosition = position;
        Vector3 curvedPosition = Vector3.Lerp(startPosition, targetPosition, t);
        curvedPosition.y += Mathf.Sin(t * Mathf.PI) * curveHeight;
        entity.position = curvedPosition;
    }
}
