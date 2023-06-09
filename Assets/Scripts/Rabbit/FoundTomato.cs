using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
public class FoundTomato : Node
{
    private Transform transform;
    private Animator animator;

    private RabbitManager rabbitManager;

    //public GameObject playerRef;

    public static LayerMask targetMask = LayerMask.GetMask("Tomato");
    public static LayerMask obstructionMask =  LayerMask.GetMask("Obstruction");


    public List<Transform> visibleTargets = new List<Transform>();

   
    public FoundTomato(Transform transform){
        this.transform = transform;
        this.animator= transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        rabbitManager = transform.GetComponent<RabbitManager>();
        Debug.Log("In FoundTomato");
        object t = GetData("tomato");
        if(t == null)
        {
            visibleTargets.Clear();
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, rabbitManager.view_radius, targetMask);
            for(int i=0;i<rangeChecks.Length;i++)
            {
                if(rangeChecks[i]==null)
                    continue;
                Transform target = rangeChecks[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, directionToTarget) < rabbitManager.angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)){
                        visibleTargets.Add(target);
                        Debug.Log("Found A Tomato");
                        parent.parent.SetData("tomato", target);
                        state = NodeState.SUCCESS;
                        return state;
                        //rabbit.SetDestination(target.position);
                        
                    }
                    else{
                        state = NodeState.FAILURE;
                        return state;
                    }
                }
                else{
                    state = NodeState.FAILURE;
                    return state;
                }            

            }
            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.RUNNING;
        return state;
    }
     
    
}
