using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class DropOff : Behavior
    {
        private GameObject Patient;

        public DropOff(TaskStackMachine tree, GameObject patient) : base(tree) {
            Patient = patient;
        }

        public override IEnumerable<Status> Run()
        {
            Patient.transform.SetParent(null);
            Patient.GetComponent<CivilianAttributes>().ForceWake = true;

            yield return Status.SUCCESS;
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }
    }
}