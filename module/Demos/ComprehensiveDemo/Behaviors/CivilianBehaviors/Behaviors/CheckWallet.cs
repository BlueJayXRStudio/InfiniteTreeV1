using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CheckWallet : Behavior
    {
        public CheckWallet(TaskStackMachine tree) : base(tree) => Debug.Log("Checking Wallet");

        public override Status CheckRequirement()
        {
            if (tree.MainObject.GetComponent<Attributes>().Cash >= 25)
                return Status.SUCCESS;
            return Status.FAILURE;
        }

        public override IEnumerable<Status> Run()
        {
            yield return CheckRequirement();
        }
    }
}