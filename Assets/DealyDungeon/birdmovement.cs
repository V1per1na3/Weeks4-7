using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TreeEditor;
using UnityEngine;

public class birdmovement : MonoBehaviour
{
    //bird is gonna speed up and run away if it overlap with player
    //bird is also the spawner of boombs
    public GameObject prefabs;
    public List<GameObject> boombs;
    public playermovmeent player;
    SpriteRenderer sr;
    float speed = 1f;
    public bool runaway = false;
    float timer = 0;
    float timeCount = 1.5f; 
    bool movingR;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boombs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        closeenough();
        normalmove();
        //Debug.Log(runaway);
    }
    void spawnit()
    {
        //spawn the bomb at bird position
        Vector2 pos = transform.position;
        GameObject newboombs = Instantiate(prefabs, pos, Quaternion.identity);
        boombs.Add(newboombs);//add to list
        Destroy(newboombs, 3);//destory after 3 sec
    }
    void normalmove()
    {
        Vector2 dir = transform.localScale;
        Vector2 pos = transform.position;
       
        pos.x += speed * Time.deltaTime;
        float halfwidth = sr.bounds.extents.x;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        /////check boundary//////
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, screenpos.y)).x+halfwidth;
            speed *= -1;//reverse speed
            dir.x *= -1;//change spirte dir

        }
        if (screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, screenpos.y)).x-halfwidth;
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
            spawnit();//spawn boombs when overlap
            //Debug.Log("overlap");
            //choose a random speed
            //I want bird to keep going to the direction of where its facing if run into player.
            //store direction using bool
            //if speed is positive, its going right, otherwise its going left
            if (speed > 0)
            {
                movingR = true;
            }
            else
            {
                movingR = false;
            }

            float randomspeed = Random.Range(3, 6);
            if (movingR)
            {    
                speed = randomspeed;
            }
            if(!movingR)//if its not moving right
            {
                speed = -randomspeed;
            }
            runaway = true;
            //give timer a countdown time
            timer = timeCount;
        }

        //if runaway is true
        if (runaway)
        {
            //start counting down
            timer -= Time.deltaTime;
            //when timer countdown to 0
            if (timer <= 0)
            {
                //dont run away anymore
                runaway = false;
                //set speed back to normal
                if (movingR)
                {
                    speed = 1f;
                }
                else
                {
                    speed = -1f;
                }
            }
        }
    }
}
