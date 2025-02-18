using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCarMovement : MonoBehaviour
{
    public float speed = 5;
    //float maxspeed = 5;run super fast if got hit
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
