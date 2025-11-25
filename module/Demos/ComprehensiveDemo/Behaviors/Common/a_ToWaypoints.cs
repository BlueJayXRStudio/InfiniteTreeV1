using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class a_ToWaypoints : Behavior
    {
        private float velocity = 1.0f;
        private int index = 0;
        private List<(int, int)> waypoints;
        private bool with_req = true;

        public a_ToWaypoints(TaskStackMachine tree, List<(int, int)> waypoints) : base(tree) {
            this.waypoints = waypoints;
            velocity = tree.MainObject.GetComponent<Attributes>().MoveSpeed;
        }

        public a_ToWaypoints(TaskStackMachine tree, List<(int, int)> waypoints, bool with_req) : base(tree) {
            this.waypoints = waypoints;
            velocity = tree.MainObject.GetComponent<Attributes>().MoveSpeed;
            this.with_req = with_req;
        }

        public override IEnumerable<Status> Run()
        {
            while (index < waypoints.Count)
            {
                if (with_req) {
                    var result = TreeRequirement();
                    if (result != Status.RUNNING) {
                        yield return result;
                    }
                }

                Vector3 ParentPos = contruct_position(waypoints[index]);
                Vector3 CurrentPos = tree.MainObject.transform.position;
                Vector3 diff = ParentPos - CurrentPos;

                if (diff.magnitude >= 0.02f) 
                {
                    tree.MainObject.transform.rotation = Quaternion.LookRotation(diff, Vector3.up);
                    tree.MainObject.transform.position += diff.normalized * velocity * Time.deltaTime;
                }
                else index++;
                
                tree.Memory.Push(this);
                yield return Status.RUNNING;
            }
            yield return Status.SUCCESS;
        }

        public void Reset(List<(int, int)> waypoints) {
            this.waypoints = waypoints;
            index = 0;
        }

        private Vector3 contruct_position ((int, int) wp) => new Vector3(wp.Item1, tree.MainObject.transform.position.y, wp.Item2);

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }
    }
}
