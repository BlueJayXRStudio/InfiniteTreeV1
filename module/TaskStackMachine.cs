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
    private Status LastMessage = Status.NULL;
    private Behavior LastTask = null;

    public TaskStackMachine(GameObject go) {
        DriverObject = go;
        Memory = new();
    }

    public Status Drive() {
        if (Memory.Count == 0) 
            return LastMessage;

        var curr_task = Memory.Pop();
        LastMessage = curr_task.Step(Memory, DriverObject, LastMessage, LastTask);
        LastTask = curr_task;

        return LastMessage;
    }

    public void AddBehavior(Behavior behavior) {
        Memory.Push(behavior);
        LastMessage = Status.NULL;
    }

    public Status GetMessage => LastMessage;
    public int GetStackCount => Memory.Count;
    public bool ProgramFinish => Memory.Count == 0;
}
