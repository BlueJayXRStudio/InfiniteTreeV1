using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class InTransport : Behavior
    {
        public InTransport(TaskStackMachine tree) : base(tree)
        {
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
