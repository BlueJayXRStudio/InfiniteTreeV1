using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class GetFood : Behavior
    {
        public GetFood(TaskStackMachine tree) : base(tree) { }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            tree.Memory.Push(
                new Sequence(
                    tree,
                    new List<Behavior>()
                    {
                        new CheckCash(tree),
                        new PurchaseFood(tree)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}