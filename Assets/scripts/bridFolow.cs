using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridFolow : MonoBehaviour
{
    public GameObject player;
    public float a,b;
    void Start()
    {
    }

    void Update()
    {
        transform.localScale = new Vector3(player.transform.localScale.x*-1,1,1);
        float player_x = player.transform.position.x;
        float player_y = player.transform.position.y;
        float camera_z = transform.position.z;
        gameObject.transform.position = new Vector3(player_x + a, player_y + b, camera_z);
    }
}
