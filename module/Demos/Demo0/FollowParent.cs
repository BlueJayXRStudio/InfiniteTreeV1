using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : Behavior
{
    private float velocity = 1.0f;

    public FollowParent(TaskStackMachine tree) : base(tree) { }

    public override Status CheckRequirement()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerable<Status> Run()
    {
        GameObject parent = tree.MainObject.GetComponent<ParentComponent>().GetParent;

        if (parent == null) {
            yield return Status.SUCCESS;
        }

        while (true)
        {
            Vector3 ParentPos = parent.transform.position;
            Vector3 CurrentPos = tree.MainObject.transform.position;
            Vector3 diff = ParentPos - CurrentPos;

            if (diff.magnitude >= 0.02f) {
                tree.MainObject.transform.position += diff.normalized * velocity * Time.deltaTime;
            }
            else {
                tree.MainObject.GetComponent<ParentComponent>().iterate();
            }

            tree.Memory.Push(this);
            yield return Status.RUNNING;
        }
    }
}
