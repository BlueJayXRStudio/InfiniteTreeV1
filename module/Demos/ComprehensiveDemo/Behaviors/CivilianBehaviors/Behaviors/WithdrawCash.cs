using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class WithdrawCash : Sequence
    {
        public WithdrawCash(TaskStackMachine tree) : base(tree, null)
        {
            Debug.Log("Need To Withdraw Cash");
            Tasks = new List<Behavior>() {
                new BeAt(tree, ExperimentBlackboard.Instance.ATMPos),
                new a_Withdraw(tree)
            };
        }
    }
}