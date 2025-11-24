using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CheckCash : Behavior
    {
        public CheckCash(TaskStackMachine tree) : base(tree)
        {
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
                        new CheckWallet(tree),
                        new WithdrawCash(tree)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}