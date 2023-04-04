using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class GotoTomato : Node
{
    private Transform transform;
    private UnityEngine.AI.NavMeshAgent rabbit;

    private Animator animator;
    
    public GotoTomato(Transform transform)
    {
        this.transform = transform;
        rabbit = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();;
        this.animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("tomato");
        rabbit.SetDestination(target.position);
        animator.Play("run");
        state = NodeState.RUNNING;
        return state;
    }

}
