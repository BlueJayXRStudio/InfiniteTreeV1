using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior
{
    protected TaskStackMachine tree;
    public IEnumerator<Status> enumerator;

    public Behavior(TaskStackMachine tree)
    {
        this.tree = tree;
        enumerator = Run().GetEnumerator();
    }
    public abstract IEnumerable<Status> Run();
    public abstract Status CheckRequirement();

    public Status TreeRequirement() {
        Stack<Behavior> tempStack = new();
        Status result = Status.RUNNING;
        
        while (tree.Memory.Count > 0)
        {
            var task = tree.Memory.Pop();
            tempStack.Push(task);
            result = task.CheckRequirement();
            if (result != Status.RUNNING) break;
        }

        while (tempStack.Count > 0)
            tree.Memory.Push(tempStack.Pop());

        return result;
    }
}
