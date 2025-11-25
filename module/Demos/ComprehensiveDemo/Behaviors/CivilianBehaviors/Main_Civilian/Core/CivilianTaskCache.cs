using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace InfiniteTree
{
    public class CivilianTaskCache : MonoBehaviour
    {
        Dictionary<string, Behavior> BehaviorCache = new();
        Dictionary<Type, object> StateCache = new();

        public object GetState(Type type, TaskStackMachine tree) {
            if (!StateCache.ContainsKey(type)) {
                object instance = Activator.CreateInstance(type, new object[] { tree });
                StateCache.Add(type, instance);
            }

            return StateCache[type];
        }
    }
}
