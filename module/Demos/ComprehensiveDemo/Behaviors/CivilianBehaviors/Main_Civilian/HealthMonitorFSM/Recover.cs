using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class Recover : Behavior
    {
        public Recover(TaskStackMachine tree) : base(tree)
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

                if (tree.MainObject.GetComponent<CivilianAttributes>().ForceWake)
                    tree.MainObject.GetComponent<CivilianAttributes>().ForceWake = false;

                if (tree.MainObject.GetComponent<Attributes>().Health > 75) {
                    Debug.Log("Recovered and resuming activity");
                    tree.MainObject.GetComponent<CivilianDriver>().SwitchTree();
                    tree.MainObject.GetComponent<CivilianDriver>().ResetTree();
                    nextState = (CivilianIdle) tree.MainObject.GetComponent<CivilianTaskCache>().GetState(typeof(CivilianIdle), tree);
                }
                
                tree.MainObject.GetComponent<Attributes>().Health += 10f * Time.deltaTime;

                tree.Memory.Push(nextState);
                yield return Status.NULL;
            }
        }
    }
}
