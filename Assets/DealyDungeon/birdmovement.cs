using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class birdmovement : MonoBehaviour
{
    //bird is gonna speed up and run away if it overlap with player
    public playermovmeent player;
    SpriteRenderer sr;
    float speed = 1f;
    float randomspeed;
    public bool runaway = false;
    float timer = 0;
    float timeCount = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position+"player");
        Debug.Log(sr.bounds+"bird");
        normalmove();
        closeenough();
        Debug.Log("speed is"+speed);
        Debug.Log("random speed is" + randomspeed);
        Debug.Log(runaway);
    }

    void normalmove()
    {
        Vector2 dir = transform.localScale;
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        
        /////check boundary//////
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
            speed *= -1;//reverse speed
            dir.x *= -1;//change spirte dir

        }
        if (screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
            speed *= -1;
            dir.x *= -1;

        }
        transform.localScale = dir;
        transform.position = pos;
    }


    void closeenough()
    {
        //if overlap
        if (sr.bounds.Contains(player.transform.position)&&!runaway)
        {
            Debug.Log("overlap");
            //choose a random speed
            //I want bird to keep going to the direction of where its facing if run into player.
            //I check dir by determinating if current speed is positive or negative.
            //if current speed is positive, assign random positive speed 
            if (speed >0)
            {
                randomspeed = Random.Range(3, 6);
            }
            else//if its negative, assign random negative speed
            {
                randomspeed = Random.Range(-6, -3);
            }
            Debug.Log(runaway);
            runaway = true;
            //give timer a countdown time
            timer = timeCount;
        }
        //if runaway is true
        if (runaway)
        {
            speed = randomspeed;//assign the random speed
            //start counting down
            timer -= Time.deltaTime;
            //when timer countdown to 0
            if (timer <= 0)
            {
                //dont run away anymore
                runaway = false;
                //set speed back to normal
                speed = 1f;
            }
        }
    }
}
