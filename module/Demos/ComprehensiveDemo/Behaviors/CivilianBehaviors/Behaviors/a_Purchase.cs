using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    internal class a_Purchase : Behavior
    {
        public a_Purchase(TaskStackMachine tree) : base(tree) { }

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

            tree.MainObject.GetComponent<Attributes>().FoodItem += 1;
            tree.MainObject.GetComponent<Attributes>().Cash -= 15;
            yield return Status.SUCCESS;
        }
    }
}