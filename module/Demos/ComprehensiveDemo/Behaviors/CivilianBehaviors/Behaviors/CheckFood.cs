using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CheckFood : Selector
    {
        public CheckFood(TaskStackMachine tree) : base(tree, null)
        {
            Debug.Log("Checking For Food");

            Tasks = new List<Behavior>() {
                new CheckInventory(tree),
                new GetFood(tree)
            };
        }
    }
}