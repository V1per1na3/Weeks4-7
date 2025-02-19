using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCarMovement : MonoBehaviour
{
    //this script is for whitecar movement and check if it's outside of screen
    //white car will start from left of screen and run to right
    //a boolean will pass condition (if outside of screen) to the spawner so spawner know when to destory the car
    public float speed = 5;
    public bool outside = false;
    public whiteCarSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        //move constanly from left to right
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //check if it's outside screen (screenright)
        if (screenpos.x >Screen.width)
        {
            outside = true;
        }
        else
        {
            outside = false;
        }

    }
}
