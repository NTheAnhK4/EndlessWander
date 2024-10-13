using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMachine : ChildBehavior
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected string curAnim;
    protected override void LoadComponentInIt()
    {
        base.LoadComponentInIt();
        LoadAnim();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        curAnim = "Idle";
    }

    protected virtual void LoadAnim()
    {
        if (animator != null) return;
        animator = transform.GetComponent<Animator>();
        Debug.Log(transform.parent.name + " Load anim successful");
    }

    public virtual void ChangeAnim(string newAnimName)
    {
        if(curAnim != String.Empty)
            animator.SetBool(curAnim, false);
        curAnim = newAnimName;
        if(curAnim != String.Empty)
            animator.SetBool(curAnim,true);
    }
}
