using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    internal class BeAt : Behavior
    {
        protected (int, int) pos;
        
        public BeAt(TaskStackMachine tree, (int, int) pos) : base(tree) { }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            tree.Memory.Push(
                new Selector(
                    tree,
                    new List<Behavior>()
                    {
                        new CheckPos(tree, pos),
                        new MoveTo(tree, pos)
                    }
                )
            );
            yield return Status.NULL;
        }
    }
}