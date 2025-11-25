using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class EatBehavior : Sequence
    {        
        public EatBehavior(TaskStackMachine tree) : base(tree, null)
        {
            Tasks = new List<Behavior>() {
                new CheckFood(tree),
                new a_EatFood(tree)
            };
        }

    }
}
