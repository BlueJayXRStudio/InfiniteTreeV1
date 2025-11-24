using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class WithdrawCash : Behavior
    {
        public WithdrawCash(TaskStackMachine tree) : base(tree)
        {
            Debug.Log("Need To Withdraw Cash");
        }

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
                        new BeAt(tree, ExperimentBlackboard.Instance.ATMPos),
                        new a_Withdraw(tree)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}