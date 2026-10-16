using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speedFly;
    public float timeFly;
    private float Direction;
    private float tmp;
    void Start()
    {
        tmp = timeFly;
        Direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeFly -= Time.deltaTime;
        if(timeFly <= 0)
        {
            Direction*=(-1);
            timeFly = tmp;
        }
        transform.Translate(new Vector3(Time.deltaTime*speedFly*Direction, 0, 0));
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
