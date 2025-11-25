using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SUCCESS OR FAIL ON ANY
public class Parallel : Behavior
{
    List<TaskStackMachine> trees;

    public Parallel(TaskStackMachine tree, List<Behavior> ParallelActions) : base(tree) {
        trees = new();
        foreach (Behavior _action in ParallelActions) {
            var _tree = new TaskStackMachine(tree.MainObject);
            _action.SetTree(_tree);
            _tree.AddBehavior(_action);
            trees.Add(_tree);
        }
    }

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerable<Status> Run()
    {
        while (true)
        {
            foreach (TaskStackMachine _tree in trees) {
                var result = _tree.Drive();
                if (result == Status.SUCCESS || result == Status.FAILURE) 
                {
                    yield return result;
                }
            }
            tree.Memory.Push(this);
            yield return Status.RUNNING;
        }
    }
}
