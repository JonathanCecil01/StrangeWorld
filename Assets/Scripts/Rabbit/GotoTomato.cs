using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class GotoTomato : Node
{
    private Transform transform;
    private UnityEngine.AI.NavMeshAgent rabbit;

    private Animator animator;
    
    public GotoTomato(Transform transform)
    {
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        
        Transform target = (Transform)GetData("tomato");
        if(target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        transform.GetComponent<NavMeshAgent>().SetDestination(target.position);
        transform.GetComponent<Animator>().Play("run");
        state = NodeState.RUNNING;
        return state;
    }

}
