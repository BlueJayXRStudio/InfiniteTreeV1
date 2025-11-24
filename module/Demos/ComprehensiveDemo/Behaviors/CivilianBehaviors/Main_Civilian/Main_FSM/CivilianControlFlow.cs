using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    // Currently this is a single state "FSM"
    public class CivilianControlFlow : Behavior
    {
        Behavior CurrentTask;

        public CivilianControlFlow(TaskStackMachine tree) : base(tree) {}

        public override IEnumerable<Status> Run()
        {
            while (true)
            {
                // push this state immediately back in, because we know
                // we will always come back to this state.
                tree.Memory.Push(this);

                if (tree.MainObject.GetComponent<Attributes>().Health < 80) {
                    // EatBehavior is a Behavior Tree. Conventionally, it wouldn't
                    // be possible to run a Behavior Tree from a state in a state
                    // machine, but by treating each behavior as a stackable task
                    // we can achieve a general engine capable of switching between
                    // an FSM and a Behavior Tree.
                    tree.Memory.Push(new EatBehavior(tree));
                    Debug.Log("Need to Eat Food. Will Try Eating Food");
                }

                yield return Status.NULL;
            }
        }

        /// <summary>
        /// We are doing this because we want to keep our health points
        /// above a certain point (i.e. HP >= 80).
        /// </summary>
        public override Status CheckRequirement()
        {
            if (CurrentTask is EatBehavior) {
                if (tree.MainObject.GetComponent<Attributes>().Health >= 80)
                    return Status.SUCCESS;
                return Status.RUNNING;
            }
            return Status.RUNNING;
        }

        
    }
}
