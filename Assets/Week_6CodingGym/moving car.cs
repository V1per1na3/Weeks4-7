using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcar : MonoBehaviour
{
    public float speed = 5;
    public carspawner sp;

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

        //check if it's outside screen (screenright)
        if (screenpos.x > Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, screenpos.y)).x;
        }
        transform.position = pos;

    }
}
