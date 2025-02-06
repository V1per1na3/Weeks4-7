using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public int dir = 3;
    public SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        Vector2 face = transform.localScale;
        Vector2 sprite = sp.transform.position;
     
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
            face.x = dir;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
            face.x = -dir;

        }
        transform.position = pos;
        transform.localScale = face;

        //if (sprite.bounds.Contains(pos))
        //{

       // }
    }
    }

