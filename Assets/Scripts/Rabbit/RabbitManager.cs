using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitManager : MonoBehaviour
{
    public float health;
    private Animator animator;
    void Start()
    {
        health = 100;
        animator = transform.GetComponent<Animator>();
    }

    public void food_intake()
    {
        health += 1;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        health-= 0.05f;
        if(health<=0 && health>=-10)
        {
            animator.Play("dead");
        }
        else if(health<=-10)
        {
            Die();
        }
    }
}
