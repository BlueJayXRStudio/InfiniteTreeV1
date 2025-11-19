using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class a_EatFood : Behavior
    {

        public a_EatFood(GameObject go) : base(go) { }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override Status Step(Stack<Behavior> memory, GameObject go, Status message, Behavior last_task)
        {
            var result = TreeRequirement(memory);
            if (result != Status.RUNNING) {
                Debug.Log($"atomic eat operation early termination result: {result}");
                return result;
            }

            go.GetComponent<Attributes>().FoodItem -= 1;
            go.GetComponent<Attributes>().Health += 15;

            return Status.SUCCESS;
        }
    }
}