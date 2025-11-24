using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CheckFood : Behavior
    {
        public CheckFood(TaskStackMachine tree) : base(tree)
        {
            Debug.Log("Checking For Food");
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            tree.Memory.Push(
                new Selector(
                    tree,
                    new List<Behavior>()
                    {
                        new CheckInventory(tree),
                        new GetFood(tree)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}