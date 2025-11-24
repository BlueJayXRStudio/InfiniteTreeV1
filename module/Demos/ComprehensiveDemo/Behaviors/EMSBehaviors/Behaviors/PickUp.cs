using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class PickUp : Behavior
    {
        public GameObject Patient;

        public PickUp(TaskStackMachine tree, GameObject patient) : base(tree) {
            Patient = patient;
        }

        public override IEnumerable<Status> Run()
        {
            Patient.transform.position = new Vector3(tree.MainObject.transform.position.x ,Patient.transform.position.y, tree.MainObject.transform.position.z);
            Patient.transform.SetParent(tree.MainObject.transform);
            
            yield return Status.SUCCESS;
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }
    }
}