using System.Collections;
using System.Collections.Generic;
using BehaviourTree;
public class Rabbit_BT : Tree
{
    public static float moveSpeed = 2f;
    public UnityEngine.GameObject gameObject;
    public UnityEngine.AI.NavMeshAgent rabbit;

    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>{
                        new Sequence(new List<Node>{
                            new FoundTomato(transform), 
                            new GotoTomato(transform),
                        }),
                        new Wander(gameObject),
        });

        return root;
    }
}
