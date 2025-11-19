using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status 
{
    SUCCESS,
    RUNNING,
    FAILURE,
    NULL
}

public class TaskStackMachine
{
    public GameObject DriverObject;
    public Stack<Behavior> Memory;
    private Status Message = Status.NULL;

    public TaskStackMachine(GameObject go) {
        DriverObject = go;
        Memory = new();
    }

    public Status Drive() {
        if (Memory.Count == 0) 
            return Message;

        Message = Memory.Pop().Step(Memory, DriverObject, Message);

        return Message;
    }

    public void AddBehavior(Behavior behavior) {
        Memory.Push(behavior);
        Message = Status.NULL;
    }

    public Status GetMessage => Message;
    public int GetStackCount => Memory.Count;
    public bool ProgramFinish => Memory.Count == 0;
}
