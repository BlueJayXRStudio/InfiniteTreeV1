using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Behavior
{
    protected bool Finished = false;
    protected List<Behavior> Tasks = new();
    protected int idx = 0;

    public Sequence(TaskStackMachine tree, List<Behavior> tasks) : base(tree) {
        Tasks = tasks;
    }

    public override IEnumerable<Status> Run()
    {
        while (idx < Tasks.Count)
        {
            tree.Memory.Push(this);
            tree.Memory.Push(Tasks[idx]);
            yield return Status.NULL;
            idx++;
            if (tree.LastMessage == Status.FAILURE)
            {
                Finished = true;
                yield return Status.FAILURE;
            }
            
        }
        Finished = true;
        yield return Status.SUCCESS;
    }
    
    public override Status CheckRequirement()
    {
        if (Finished)
            return Status.FAILURE;

        for (int i = 0; i < idx; i++) {
            var result = Tasks[i].CheckRequirement();
            if (result != Status.SUCCESS)
                return Status.FAILURE;
        }
        return Status.RUNNING;
    }

}
