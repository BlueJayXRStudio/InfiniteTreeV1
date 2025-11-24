using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : Behavior
{
    public RotateBehavior(TaskStackMachine tree) : base(tree) {}

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerable<Status> Run()
    {
        tree.MainObject.transform.rotation = Quaternion.Euler(0, 180 * Time.deltaTime, 0) * tree.MainObject.transform.rotation;
        tree.Memory.Push(this);
        yield return Status.RUNNING;
    }
}
