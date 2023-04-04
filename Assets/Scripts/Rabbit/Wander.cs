using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class Wander : Node
{
    //public float moveSpeed = 1f;
    public float rotationSpeed = 50f;
    public double health = 100;

    private GameObject gameObject;
    Animator rabbitAnim;

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
        Transform transform  = gameObject.transform;
        if(health <=0 && health>= -20)
        {
            Death();
        }
        else if(health<-20)
        {
            //Destroy(gameObject);
        }
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
                transform.position += transform.forward*Time.deltaTime*Rabbit_BT.moveSpeed;
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
                    transform.Rotate(transform.up*Time.deltaTime*rotationSpeed);
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
                    transform.Rotate(transform.up*Time.deltaTime*rotationSpeed);
                    rot_counter+= Time.deltaTime;
                    if(rot_counter>=rotWait)
                    {
                        isRotatingRight = false;
                        rot_counter = 0;
                        isRunning = true;
                    }
                }
            }
            //isIdle = true;
        }

            // isWandering = true;
            // Thread.Sleep(runWait*10);
            // isRunning = true;
            // if(isRunning == true){
            //     gameObject.GetComponent<Animator>().Play("run");
            //     transform.position += transform.forward*Time.deltaTime*Rabbit_BT.moveSpeed;
            // }
            // isRunning = false;
            // if (rotLorR == 1){
            //     isRotatingLeft = true;
            //     Thread.Sleep(rotTime*10);
            //     gameObject.GetComponent<Animator>().Play("idle");
            //     transform.Rotate(transform.up*Time.deltaTime*rotationSpeed);
            //     isRotatingLeft= false;
            // }
            // if (rotLorR == 2){
            //     isRotatingRight = true;
            //     Thread.Sleep(rotTime*10);
            //     gameObject.GetComponent<Animator>().Play("idle");
            //     transform.Rotate(transform.up*Time.deltaTime*rotationSpeed);
            //     isRotatingRight= false;
            // }
            // isWandering = false;

        
        
        health -= 0.05;
        state = NodeState.RUNNING;
        return state;
    }

    /*void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Tomato"))
        {
            //Destroy(other.gameObject);
            health+=2;
        }
    }*/

    void Death()
    {
        rabbitAnim.SetBool("isDead", true);
    }

    /*public IEnumerator WanderRoutine()
    {
        int rotTime  = Random.Range(1, 3);
        int rotWait = Random.Range(1, 4);
        int rotLorR = Random.Range(1, 2);
        int runWait = Random.Range(1, 5);
        int runTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(runWait);
        isRunning = true;
        yield return new WaitForSeconds(runTime);
        isRunning = false;
        yield return new WaitForSeconds(rotWait);

        if (rotLorR == 1){
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft= false;
        }
        if (rotLorR == 2){
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight= false;
        }

        isWandering = false;

    }*/
}
