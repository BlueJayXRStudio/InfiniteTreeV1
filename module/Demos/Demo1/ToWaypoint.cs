using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWaypoint : Behavior
{
    private float velocity = 2.3f;
    private GameObject waypoint;

    public ToWaypoint(TaskStackMachine tree, GameObject waypoint) : base(tree)
    {
        this.waypoint = waypoint;
    }

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerable<Status> Run()
    {        
        while (true) {
            // Debug.Log("Traveling to Way Point");
            if (!waypoint.activeSelf) {
                yield return Status.FAILURE;
            }

            Vector3 ParentPos = waypoint.transform.position;
            Vector3 CurrentPos = tree.MainObject.transform.position;
            Vector3 diff = ParentPos - CurrentPos;
            if (diff.magnitude >= 0.02f)
            {
                tree.MainObject.transform.position += diff.normalized * velocity * Time.deltaTime;
                tree.Memory.Push(this);
                yield return Status.RUNNING;
            }
            else 
            {
                yield return Status.SUCCESS;
            }
        }
    }
}
