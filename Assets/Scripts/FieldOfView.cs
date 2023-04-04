
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    //public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public UnityEngine.AI.NavMeshAgent rabbit;

    public List<Transform> visibleTargets = new List<Transform>();

    public bool canSeePlayer;

    private void Update()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Tomato");
        StartCoroutine("FOVRoutine");
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        visibleTargets.Clear();
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for(int i=0;i<rangeChecks.Length;i++)
        {
            if(rangeChecks[i]==null)
                continue;
            Transform target = rangeChecks[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)){
                    visibleTargets.Add(target);
                    rabbit.SetDestination(target.position);
                    gameObject.GetComponent<Animator>().Play("run");
                }
            }            


        }
        /*if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)){
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;*/
    }
}
