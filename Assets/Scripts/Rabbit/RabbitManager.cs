using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitManager : MonoBehaviour
{
    public float health;// = Random.Range(75, 120);
    public float speed;// = Random.Range(1f, 3f);

    public float rot_speed;// = Random.Range(30, 120);

    public float view_radius;// = Random.Range(2, 5);

    [Range(0, 360)]
    public float angle;
    private Animator animator;
    private RabbitCountManager rabbitCountManager;
    void Start()
    {
        health = Random.Range(75, 120);
        speed = Random.Range(1f, 3f);
        rot_speed = Random.Range(30, 120);
        view_radius = Random.Range(2, 5);
        angle = Random.Range(50, 200);
        animator = transform.GetComponent<Animator>();
        rabbitCountManager = transform.GetComponent<RabbitCountManager>();
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
        health-= 0.5f;
        if(health<=0 && health>=-10)
        {
            animator.Play("dead");
            
        }
        else if(health<=-10)
        {
            //rabbitCountManager.Death();
            Die();
        }
    }
}
