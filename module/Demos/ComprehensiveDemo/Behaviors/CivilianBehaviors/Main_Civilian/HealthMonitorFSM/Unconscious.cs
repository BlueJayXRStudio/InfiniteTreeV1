using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class Unconscious : Behavior
    {
        public Unconscious(TaskStackMachine tree) : base(tree)
        {
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        // bool isPickedUp = false;        
        public override IEnumerable<Status> Run()
        {
            while (true)
            {
                Behavior nextState = this;

                if (tree.MainObject.GetComponent<CivilianAttributes>().ForceWake) {
                    Debug.Log("Waking up. Starting Recovery :D");
                    nextState = (Recover) tree.MainObject.GetComponent<CivilianBehaviorFactory>().GetState(typeof(Recover), tree.MainObject);
                }

                tree.Memory.Push(nextState);
                yield return Status.NULL;
            }
        }
    }
}
