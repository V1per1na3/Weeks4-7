using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovmeent : MonoBehaviour
{
    SpriteRenderer sr;
    public float speed =2f;
    //public float health;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        //this is for player movement and ctrl
        //plyaer goes left and right with input keycode A & D
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        ///////////////////////////////
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }
        /////check boundary//////
        float halfwidth = sr.bounds.extents.x;
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + halfwidth;

        }
        if(screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - halfwidth;
        }
        transform.position = pos;
    }
}
