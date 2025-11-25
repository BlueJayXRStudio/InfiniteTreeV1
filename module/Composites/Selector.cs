using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Behavior
{
    protected bool Finished = false;
    protected List<Behavior> Tasks = new();
    protected int idx = 0;

    public Selector(TaskStackMachine tree, List<Behavior> tasks) : base(tree) {
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
            if (tree.LastMessage == Status.SUCCESS)
            {
                Finished = true;
                yield return Status.SUCCESS;
            }
        }
        Finished = true;
        yield return Status.FAILURE;
    }
    
    public override Status CheckRequirement()
    {
        for (int i = 0; i < idx; i++) {
            var result = Tasks[i].CheckRequirement();
            if (result != Status.FAILURE)
                return Status.SUCCESS;
        }

        if (!Finished)
            return Status.RUNNING;
        return Status.FAILURE;
    }
}