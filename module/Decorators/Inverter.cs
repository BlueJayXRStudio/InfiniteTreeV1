using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Behavior
{
    Behavior ToInvert;
    
    public Inverter(Behavior toInvert, GameObject go) : base(go) {
        ToInvert = toInvert;
    }

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override Status Step(Stack<Behavior> memory, GameObject go, Status message)
    {
        if (message == Status.NULL) {
            memory.Push(this);
            memory.Push(ToInvert);
            return Status.NULL; }
        else if (message == Status.SUCCESS)
            return Status.FAILURE;
        else 
            return Status.SUCCESS;
    }

}
