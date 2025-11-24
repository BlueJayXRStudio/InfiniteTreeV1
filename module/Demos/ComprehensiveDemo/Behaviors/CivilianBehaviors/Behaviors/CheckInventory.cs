using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CheckInventory : Behavior
    {
        public CheckInventory(TaskStackMachine tree) : base(tree) => Debug.Log("Checking Inventory");

        public override Status CheckRequirement()
        {
            if (tree.MainObject.GetComponent<Attributes>().FoodItem <= 0)
                return Status.FAILURE;
            return Status.SUCCESS;
        }

        public override IEnumerable<Status> Run()
        {
            yield return CheckRequirement();
        }
    }
}