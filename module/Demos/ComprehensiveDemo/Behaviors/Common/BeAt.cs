using System.Collections.Generic;
using UnityEngine;

namespace InfiniteTree
{
    internal class BeAt : Selector
    {
        protected (int, int) pos;
        
        public BeAt(TaskStackMachine tree, (int, int) pos) : base(tree, null) 
        { 
            this.pos = pos;
            Tasks = new List<Behavior>()
            {
                new CheckPos(tree, pos),
                new MoveTo(tree, pos)
            };
        }

    }
}