using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        if( screenpos.x < 0)
        {
            Vector3 fixedpos = new Vector3(0, 0, 0);
            pos.x = Camera.main.ScreenToWorldPoint(fixedpos).x;
            speed *= -1;
        }

        if (screenpos.x > Screen.width)
        {
            Vector3 fixedpos = new Vector3(Screen.width, 0, 0);
            pos.x = Camera.main.ScreenToWorldPoint(fixedpos).x;
            speed *= -1;
        }
        transform.position = pos;
    }

    public void Go(float s)
    {
        speed = s;
    }

    public void stopit()
    {
        speed = 0;
    }
}

