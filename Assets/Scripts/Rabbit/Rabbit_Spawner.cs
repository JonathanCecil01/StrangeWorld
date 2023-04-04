using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit_Spawner : MonoBehaviour
{
    public GameObject rabbit;
    public int count = 8;
    void Start()
    {
        for(int i=0;i<count;i++){
            NavMeshTriangulation triangulation = NavMesh.CalculateTriangulation();
            int vertexIndex = Random.Range(0, triangulation.vertices.Length);
            NavMeshHit Hit;
            if(NavMesh.SamplePosition(triangulation.vertices[vertexIndex], out Hit, 1f, NavMesh.AllAreas))
            {
                //print("Hit");
                Instantiate(rabbit, Hit.position, Quaternion.Euler(Random.Range(0.0f, 360.0f),0 , Random.Range(0.0f, 360.0f)));
            }
            else{
                //print("NoHit");
            }
            //Vector3 randompos = new Vector3(Random.Range(-3, 3), 5, Random.Range(-3, 3));
            //Instantiate(rabbit, randompos, Quaternion.identity);   
        }
    }
}
