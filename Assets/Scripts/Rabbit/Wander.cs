using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class Wander : Node
{
    //public float moveSpeed = 1f;
    private RabbitManager rabbitManager;

    private GameObject gameObject;

    private bool isIdle=  true;
    private bool isRotatingLeft= false;
    private bool isRotatingRight= false;
    private bool isRunning= false;

    float  wait_counter = 0;
    float run_counter = 0;
    float rot_counter = 0f;
    float rotTime  = 1f;//Random.Range(1, 3);
    float  rotWait = 1f;//Random.Range(1, 4);
    float runWait = 1f;//Random.Range(1, 5);
    float runTime = 1f;//Random.Range(1, 6);
    public Wander(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
    public override NodeState Evaluate()
    {
        Debug.Log("In Wander");
        Transform transform  = gameObject.transform;
        rabbitManager = transform.GetComponent<RabbitManager>();
        if(isIdle)
        {
            wait_counter+= Time.deltaTime;
            gameObject.GetComponent<Animator>().Play("idle");
            if (wait_counter>= rotWait)
            {
                isIdle = false;
                isRunning = true;
                run_counter = 0f;
            }
        }
        else{
            if(isRunning){
                gameObject.GetComponent<Animator>().Play("run");
                transform.position += transform.forward*Time.deltaTime*rabbitManager.speed;
                run_counter+= Time.deltaTime;
                if(run_counter>= runWait)
                {
                    isRunning = false;
                    isRotatingLeft = true;
                    isRotatingRight= true;
                    wait_counter = 0f;
                    isIdle= true;
                }
            }
            int  rotLorR = Random.Range(1, 2);
            if (rotLorR == 1){
                if(isRotatingLeft){
                    gameObject.GetComponent<Animator>().Play("idle");
                    transform.Rotate(transform.up*Time.deltaTime*rabbitManager.rot_speed);
                    rot_counter+= Time.deltaTime;
                    if(rot_counter>=rotWait)
                    {
                        isRotatingLeft = false;
                        rot_counter = 0;
                        isRunning = true;
                    }
                }
            }
            else if (rotLorR == 2){
                if(isRotatingRight){
                    gameObject.GetComponent<Animator>().Play("idle");
                    transform.Rotate(transform.up*Time.deltaTime*rabbitManager.rot_speed);
                    rot_counter+= Time.deltaTime;
                    if(rot_counter>=rotWait)
                    {
                        isRotatingRight = false;
                        rot_counter = 0;
                        isRunning = true;
                    }
                }
            }
        }

        
        state = NodeState.RUNNING;
        return state;
    }
}
