using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class CivilianIdle : Behavior
    {
        public CivilianIdle(TaskStackMachine tree) : base(tree)
        {
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            while (true)
            {
                Behavior nextState = this;

                if (tree.MainObject.GetComponent<Attributes>().Health < 20) {
                    Debug.Log("Civilian passed out");    
                    // Call EMS
                    ExperimentBlackboard.Instance.SetCall(tree.MainObject);
                    // Pause main control flow tree. An unconscious person most likely would not be thinking :O
                    tree.MainObject.GetComponent<CivilianDriver>().SwitchTree();
                    // Set next state as "Unconscious"
                    nextState = (Unconscious) tree.MainObject.GetComponent<CivilianBehaviorFactory>().GetState(typeof(Unconscious), tree.MainObject);
                }
                // By only pushing the next state, we ensure that the next state will be on top of the stack memory.
                tree.Memory.Push(nextState);
                yield return Status.NULL;
            }
        }
    }
}


