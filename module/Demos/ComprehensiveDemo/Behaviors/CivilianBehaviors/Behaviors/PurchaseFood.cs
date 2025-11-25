using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    internal class PurchaseFood : Sequence
    {
        public PurchaseFood(TaskStackMachine tree) : base(tree, null)
        {
            Tasks = new List<Behavior>() {
                new BeAt(tree, ExperimentBlackboard.Instance.GroceryStorePos),
                new a_Purchase(tree)
            };
        }
    }
}