using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class EMSControlFlow : Behavior
    {
        public EMSControlFlow(TaskStackMachine tree) : base(tree) { }

        public override IEnumerable<Status> Run()
        {
            while (true)
            {
                GameObject Call = ExperimentBlackboard.Instance.GetCall;
                
                tree.Memory.Push(this);
                if (Call != null)
                    tree.Memory.Push(new TransportPatient(tree, Call));
                
                yield return Status.NULL;
                
            }
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }
    }
}
