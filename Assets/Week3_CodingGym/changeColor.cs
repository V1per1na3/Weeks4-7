using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public float offset = 0.5f;
    public SpriteRenderer sp;
    public bool mouseoverP=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = transform.position;
        if (mouse.x >= pos.x - offset && mouse.x <= pos.x + offset && mouse.y >= pos.y - offset && mouse.y <= pos.y + offset)
        {
            mouseoverP = true;
        }
        else
        {
            mouseoverP = false;
        }

        if (mouseoverP)
        {
            sp.color = Color.red;
        }
        else
        {
            sp.color = Color.white;
        }
    }
}
