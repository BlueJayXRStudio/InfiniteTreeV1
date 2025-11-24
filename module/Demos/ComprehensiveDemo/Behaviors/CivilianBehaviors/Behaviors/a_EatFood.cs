using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class a_EatFood : Behavior
    {

        public a_EatFood(TaskStackMachine tree) : base(tree) { }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            var result = TreeRequirement();
            if (result != Status.RUNNING) {
                Debug.Log($"atomic eat operation early termination result: {result}");
                yield return result;
            }

            tree.MainObject.GetComponent<Attributes>().FoodItem -= 1;
            tree.MainObject.GetComponent<Attributes>().Health += 15;
            yield return Status.SUCCESS;
        }

    }
}