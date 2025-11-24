using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    internal class a_Withdraw : Behavior
    {
        public a_Withdraw(TaskStackMachine tree) : base(tree)
        {
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            var result = TreeRequirement();
            if (result != Status.RUNNING) {
                yield return result;
            }
            
            Debug.Log("Retrieved cash");
            tree.MainObject.GetComponent<Attributes>().Cash += 50;
            yield return Status.SUCCESS;
        }
    }
}