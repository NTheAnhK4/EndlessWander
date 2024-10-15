
using UnityEngine;

public interface ILeg : IEntity
{
    protected void Walk()
    {
        
    }

    protected void Run()
    {
        
    }

    protected void Jump()
    {
        
    }

    protected void Stand()
    {
        
    }
}

public enum MainLegEvent
{
    Walk,
    Run,
    Jump,
    Stand
}
