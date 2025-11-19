using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : Behavior
{
    private float velocity = 1.0f;

    public FollowParent(GameObject go) : base(go) { }

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override Status Step(Stack<Behavior> memory, GameObject go, Status message, Behavior last_task)
    {
        GameObject parent = go.GetComponent<ParentComponent>().GetParent;

        if (parent == null) {
            return Status.SUCCESS;
        }

        Vector3 ParentPos = parent.transform.position;
        Vector3 CurrentPos = go.transform.position;
        Vector3 diff = ParentPos - CurrentPos;

        if (diff.magnitude >= 0.02f) {
            go.transform.position += diff.normalized * velocity * Time.deltaTime;
        }
        else {
            // go.transform.position = parent.transform.position;
            go.GetComponent<ParentComponent>().iterate();
        }

        memory.Push(this);
        return Status.RUNNING;
    }
}
