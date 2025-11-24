using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class EatBehavior : Behavior
    {        
        public EatBehavior(TaskStackMachine tree) : base(tree) { }

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
                        new CheckFood(tree),
                        new a_EatFood(tree)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}
