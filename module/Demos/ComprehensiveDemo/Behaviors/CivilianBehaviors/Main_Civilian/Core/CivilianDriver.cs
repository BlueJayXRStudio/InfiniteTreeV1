using System.Collections;
using System.Collections.Generic;
using InfiniteTree;
using UnityEngine;

public class CivilianDriver : MonoBehaviour
{
    TaskStackMachine tree;
    TaskStackMachine HealthStates;

    bool treePaused = false;
    bool HealthStatesPaused = false;

    void Awake()
    {
        tree = new(gameObject);
        HealthStates = new(gameObject);
    }

    void Start()
    {
        tree.AddBehavior(new CivilianControlFlow(tree));
        HealthStates.AddBehavior((CivilianIdle) GetComponent<CivilianBehaviorFactory>().GetState(typeof(CivilianIdle), gameObject));
    }

    void Update()
    {
        if (!treePaused) tree.Drive();
        if (!HealthStatesPaused) HealthStates.Drive();
    }

    public void ResetTree()
    {
        tree.Memory = new Stack<Behavior>();
        tree.AddBehavior(new CivilianControlFlow(tree));
    }

    public void SwitchTree() => treePaused = !treePaused;

}
