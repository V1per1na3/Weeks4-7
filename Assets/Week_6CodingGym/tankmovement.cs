using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    public float speed = 1;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        //move tank
        //if player press A, tank goes to left
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
        }
        //if player press D, tank goes to right
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }
        //check boundary and prevent player to run ouside the camera space
        //in week6 reading, learned how to use bound to get the size of sprite
        //unity says extents = half of size, i can probably use this to make the checkedge function work
        //so that even I change the size and stuff it still work properly?
        float halfwidth = sr.bounds.extents.x;//since player is only going left and right, i only need x
        //if player hits the left side, position of player = left side of camera space
        if (screenpos.x< 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + halfwidth;
        }
        //if player hits the right side, position of player = right side of camera space
        if (screenpos.x > Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - halfwidth;
        }

        transform.position = pos;
        
    }
    public void fast (float s)//for button add speed
    {
        speed +=1;
    }

    public void slow (float s)//for button reduce speed
    {
        speed -= 1;
    }
}
