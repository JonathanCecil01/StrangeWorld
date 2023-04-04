using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public enum NodeState{
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState state;
        public Node parent;
        protected List<Node> children;

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();
        public Node()
        {
            parent = null;
        }
        public Node (List<Node> children)
        {
            this.children = children;
            foreach(var child in children){
                child.parent = this;
            }
        }
        
        private void _addChild(Node child)
        {
            child.parent = this;
            children.Add(child);
        }
        public virtual NodeState Evaluate() => NodeState.FAILURE; 

        public void SetData(string key, object val){
            _dataContext[key] = val;
        }

        public object GetData(string key)
        {
            object value = null;
            if(_dataContext.TryGetValue(key, out value))
                return value;
            Node node = parent;
            while(node!=null)
            {
                value = node.GetData(key);
                if(value!=null)
                    return value;
                node= node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            object value = null;
            if(_dataContext.ContainsKey(key))
                _dataContext.Remove(key);
            Node node = parent;
            while(node!=null)
            {
                bool cleared = node.ClearData(key);
                if(cleared)
                    return true;
                node= node.parent;
            }
            return false;
        }
        
    }
}


