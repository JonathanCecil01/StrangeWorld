using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using BehaviourTree;
public class Rabbit_BT : Tree
{
    public static float moveSpeed = 2f;
    public static float eat_range = 1f;
    public UnityEngine.GameObject gameObject;

    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>{
                        new Sequence(new List<Node>{
                            new EatableRange(transform),
                            new EatTomato(transform),
                        }),
                        new Sequence(new List<Node>{
                            new FoundTomato(transform), 
                            new GotoTomato(transform),
                        }),
                        new Wander(gameObject),
        });
        //Node root = new Selector(new List<Node>{new Wander(gameObject)});


        return root;
    }
}
