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
    public GameObject MainObject;
    public Stack<Behavior> Memory;
    public Status LastMessage = Status.NULL;
    public Behavior LastTask = null;

    public TaskStackMachine(GameObject go) {
        Memory = new();
        MainObject = go;
    }

    public Status Drive() {
        if (Memory.Count == 0) 
            return LastMessage;

        var curr_task = Memory.Pop();
        curr_task.enumerator.MoveNext();
        LastMessage = curr_task.enumerator.Current;
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
