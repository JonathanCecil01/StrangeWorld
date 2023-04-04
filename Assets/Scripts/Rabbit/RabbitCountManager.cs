using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCountManager : MonoBehaviour
{
    public int population;
    void Start()
    {
    }

    public void Birth(int n)
    {
        population +=n;
    }
    public void Death()
    {
        population -=1;
    }
}
