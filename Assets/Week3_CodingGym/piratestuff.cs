using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class piratestuff : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mouseoverP;//check if mouse is over pirate
    public bool poped;//check if it pops
    public bool isclicked;//check if its been clicked already.
    public SpriteRenderer sr;
    public float offset = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 pos = transform.position;
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouse.x >= pos.x - offset && mouse.x <= pos.x + offset && mouse.y >= pos.y - offset && mouse.y <= pos.y + offset)
            //check if mouse is over the pirate
        {
            mouseoverP = true;
        }
        else
        {
            mouseoverP = false;
        }

        if(mouseoverP && Input.GetMouseButtonDown(0))//if mouse is over pirate and click
        {

            int outcome = Random.Range(1, 3);//randomly generate 1 or 2
            sr.color = Color.red;//change the color
            if(outcome == 1)//if its 1, it will pop!
            {
                poped = true;
                Debug.Log("you lost!");
            }
            else
            {
                poped = false;
                Debug.Log("safe!");
            }
        }
    }
}
