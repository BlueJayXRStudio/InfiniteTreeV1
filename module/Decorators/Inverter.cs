using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Behavior
{
    Behavior ToInvert;
    
    public Inverter(TaskStackMachine tree, Behavior to_invert) : base(tree)
    {
        ToInvert = to_invert;
    }

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerable<Status> Run()
    {
        tree.Memory.Push(this);
        tree.Memory.Push(ToInvert);
        yield return Status.NULL; 
        
        if (tree.LastMessage == Status.SUCCESS)
            yield return Status.FAILURE;
        yield return Status.SUCCESS;
    }
}
