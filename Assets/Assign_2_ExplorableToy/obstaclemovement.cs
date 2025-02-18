using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclemovement : MonoBehaviour
{
    //this script is for obstacle movement and also check if its position is outside of screen...
    //obstacle move from right to left.
    //bool outside is for spawner to know when to destory the obstacle.
    public float speed = 1;
    public bool outside = false;
    public obstacleSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 5);//random speed
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        //move constanly from right to left
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;

        //check if it's outside screen (screenleft)
        if (screenpos.x <= 0)
        {
            outside = true;
        }
        else
        {
            outside = false;
        }

    }
}
