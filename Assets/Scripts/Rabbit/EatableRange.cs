using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class EatableRange : Node
{
    private Transform transform;

    public EatableRange(Transform transform)
    {
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t =  GetData("tomato");
        if(t==null){
            state  = NodeState.FAILURE;
            return state;
        }
        Transform target = (Transform)t;
        if(target ==  null)
        {
            state  = NodeState.FAILURE;
            return state;
        }
        if(Vector3.Distance(transform.position, target.position)<= Rabbit_BT.eat_range)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
        
    }
}
