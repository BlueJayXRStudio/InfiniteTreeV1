using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class MoveTo : Behavior
    {
        a_ToWaypoints moveTo;
        (int, int) destination;

        bool with_req = true;
        bool Finished = false;

        public MoveTo(TaskStackMachine tree, (int, int) dest) : base(tree) {
            destination = dest;
        }

        public MoveTo(TaskStackMachine tree, (int, int) dest, bool with_req) : base(tree) {
            destination = dest;
            this.with_req = with_req;
        }

        public override Status CheckRequirement()
        {
            if (!Finished) return Status.RUNNING;
            return Status.FAILURE;
        }

        public override IEnumerable<Status> Run()
        {
            var waypoints = ExperimentBlackboard.Instance.ShortestPath(ExperimentBlackboard.Instance.map, tree.MainObject.GetComponent<Attributes>().GetPos, destination);
            moveTo ??= !with_req ? new a_ToWaypoints(tree, waypoints, with_req) : new a_ToWaypoints(tree, waypoints);
            tree.Memory.Push(this);
            tree.Memory.Push(moveTo);
            yield return Status.NULL;

            Finished = true;
            yield return tree.LastMessage;
        }

    }
}