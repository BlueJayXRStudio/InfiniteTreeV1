using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    public class TransportPatient : Behavior
    {
        private GameObject DriverObject;
        private GameObject Patient;

        private List<Behavior> ToDo = new();

        public TransportPatient(TaskStackMachine tree, GameObject patient) : base(tree) {
            // Debug.Log("transporting patient!");
            Patient = patient;

            // ToDo.Add(new ToWaypoints(this.Patient.GetComponent<Attributes>().GetPos));

            // var MoveToPatient = DriverObject.GetComponent<EMSBehaviorFactory>().GetNewMoveBehavior(DriverObject, Patient.GetComponent<Attributes>().GetPos);
            // var MoveToHospital = DriverObject.GetComponent<EMSBehaviorFactory>().GetNewMoveBehavior(DriverObject, ExperimentBlackboard.Instance.HospitalPos);

            ToDo.Add(new MoveTo(tree, Patient.GetComponent<Attributes>().GetPos, false));
            ToDo.Add(new PickUp(tree, Patient));
            ToDo.Add(new MoveTo(tree, ExperimentBlackboard.Instance.HospitalPos, false));
            ToDo.Add(new DropOff(tree, Patient));
        }

        public override Status CheckRequirement()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Status> Run()
        {
            tree.MainObject.GetComponent<EMSAttributes>().lightsController.transform.gameObject.SetActive(true);
            if (tree.LastMessage == Status.SUCCESS) {
                tree.MainObject.GetComponent<EMSAttributes>().lightsController.transform.gameObject.SetActive(false);
                yield return Status.SUCCESS;
            }
            tree.Memory.Push(this);
            tree.Memory.Push(new Sequence(tree, ToDo));
            yield return Status.NULL;
        }
        
    }
}