using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit_Vision : MonoBehaviour
{
    public float radius;
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start(){
        playerRef = GameObject.FindGameObjectWithTag("Tomato");
        FieldOfViewCheck() ;
    }


    /*private IEnumerator FoVRoutine{
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        while(true){
                yield return wait;
                FieldOfViewCheck();
        }
    }*/

    private void FieldOfViewCheck()
    {
        Collider [] rangeChecks = Physics.OverlapSphere(transform.forward, radius, targetMask);
        if(rangeChecks.Length!=0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.position, directionToTarget) <= angle/2)
            {
                float distanceToTarget = Vector3.Distance(target.position, transform.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false; 
            }
            else{
                canSeePlayer = false;
            }
        }
        else if(canSeePlayer)
            canSeePlayer = false;
    }


}
