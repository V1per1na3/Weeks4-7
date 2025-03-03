using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5f;
    public int dir = 1;
    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        //move around the screen
        Vector2 pos = transform.position;
        Vector2 face = transform.localScale;//change sprite direction
        Vector2 sprite = sp.transform.position;
        //goleft
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
            face.x = dir;
        }
        //goright
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
            face.x = -dir;
        }
        //go up
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += Time.deltaTime * speed;
            face.x = dir;
        }
        //go down
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= Time.deltaTime * speed;
            face.x = dir;
        }
        transform.position = pos;
        transform.localScale = face;
    }
}
