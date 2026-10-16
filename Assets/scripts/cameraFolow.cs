using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFolow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float player_x = player.transform.position.x;
        float player_y = player.transform.position.y;
        float camera_z = transform.position.z;
        gameObject.transform.position = new Vector3(player_x, player_y, camera_z);
    }
}
