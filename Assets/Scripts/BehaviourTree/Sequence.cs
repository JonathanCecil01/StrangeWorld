using System.Collections;

namespace BehaviourTree{
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            bool isChildRunning = false;
            foreach(Node node in children)
            {
                switch(node.Evaluate()){
                    case NodeState.FAILURE: state = NodeState.FAILURE;  return state;
                    case NodeState.SUCCESS: continue;
                    case NodeState.RUNNING:isChildRunning = true; continue;
                    default: state = NodeState.SUCCESS; return state;
                }
            }
            state = isChildRunning? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }
}