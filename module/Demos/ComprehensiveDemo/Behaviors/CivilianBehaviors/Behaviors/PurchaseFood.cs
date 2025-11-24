using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    internal class PurchaseFood : Behavior
    {
        public PurchaseFood(TaskStackMachine tree) : base(tree) { }

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
                        new BeAt(tree, ExperimentBlackboard.Instance.GroceryStorePos),
                        new a_Purchase(tree)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}