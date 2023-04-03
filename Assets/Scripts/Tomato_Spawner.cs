using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tomato_Spawner : MonoBehaviour
{
    public GameObject tomato;
    public int count = 100;
    void Start()
    {
        for(int i=0;i<count;i++){
            NavMeshTriangulation triangulation = NavMesh.CalculateTriangulation();
            int vertexIndex = Random.Range(0, triangulation.vertices.Length);
            NavMeshHit Hit;
            if(NavMesh.SamplePosition(triangulation.vertices[vertexIndex], out Hit, 1f, NavMesh.AllAreas))
            {
                //print("Hit");
                GameObject tomato_ = tomato;
                tomato_.tag = "Tomato";
                Instantiate(tomato_, Hit.position, Quaternion.identity);
            }
            else{
                //print("NoHit");
            }
            //Vector3 randompos = new Vector3(Random.Range(-3, 3), 5, Random.Range(-3, 3));
            //Instantiate(rabbit, randompos, Quaternion.identity);   
        }
    }
}
