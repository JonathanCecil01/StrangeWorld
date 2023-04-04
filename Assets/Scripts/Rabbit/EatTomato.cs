using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class EatTomato : Node
{
    private TomatoManager tomatoManager;
    private RabbitManager rabbitManager;
    private Transform last_transform;
    private Transform transform;

    public EatTomato(Transform transform)
    {
        this.transform = transform;
    }
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("tomato");
        rabbitManager = transform.GetComponent<RabbitManager>();
        if(target!= last_transform)
        {
            tomatoManager = target.GetComponent<TomatoManager>();
            last_transform = target;
        }
        
        tomatoManager.Die();
        ClearData("tomato");
        rabbitManager.food_intake();
        state = NodeState.SUCCESS;
        return state;

    }
}
