using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class GetFood : Sequence
    {
        public GetFood(TaskStackMachine tree) : base(tree, null)
        {
            Tasks = new List<Behavior>() {
                new CheckCash(tree),
                new PurchaseFood(tree)
            };
        }
    }
}