using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Enemy_speed_walk;
    public float Enemy_time_walk;
    private float a;
    void Start()
    {
        a = Enemy_time_walk;
    }

    void Update()
    {
        Enemy_time_walk-=Time.deltaTime;
        if(Enemy_time_walk <= 0)
        {
            transform.localScale = new Vector3(transform.localScale.x*-1,1,1);
            Enemy_time_walk = a;
            Enemy_speed_walk*=-1;
        }
        transform.Translate(new Vector3(Time.deltaTime*Enemy_speed_walk,0,0));

    }
}
