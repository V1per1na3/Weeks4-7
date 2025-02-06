using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class piratestuff : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mouseoverP;//check if mouse is over pirate
    public bool poped=false;//check if it pops
    public bool isclicked=false;//check if its been clicked already.
    public SpriteRenderer sr;
    public float offset = 0.5f;
    public pirateSpawner thingthatspawnMe;
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

        if(!isclicked && mouseoverP && Input.GetMouseButtonDown(0))//if mouse is over pirate and its never been clicked and click
        {
            isclicked = true;//got clicked
            int outcome = Random.Range(1, 3);//randomly generate 1 or 2
            sr.color = Color.red;//mark it to different color just for visual purposes

            if(outcome == 1)//if its 1, it will pop!
            {
                poped = true;
                thingthatspawnMe.Gameover();//game over from spawner script
                Debug.Log("you lost!");
            }
            else
            {//if its not 1, it's safe!
                poped = false;
                thingthatspawnMe.niceclick++;//start counting success click
                if (thingthatspawnMe.niceclick == 5)
                {
                    Debug.Log("you win!");
                    thingthatspawnMe.Gameover();//if success click =5, wins the game
                }
                else
                {
                    Debug.Log("safe!");//if success clicks are less than 5 just say its safe.
                }
                
            }
        }
    }
}
