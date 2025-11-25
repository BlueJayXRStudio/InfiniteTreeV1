using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CheckCash : Selector
    {
        public CheckCash(TaskStackMachine tree) : base(tree, null)
        {
            Tasks = new List<Behavior>() {
                new CheckWallet(tree),
                new WithdrawCash(tree)
            };
        }
    }
}