using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    //this script is for all the bird (player avatart) elements.
    //bird will be always falling if its in the air bc of gravity
    //player can hit space bar to flap (fly) and use A and D to control left and right
    //bird will have initial hp of 3 hearts, if bird hit obstacle or car each time, it decrease by 1
    //if bird hp=0, trigger lose page
    SpriteRenderer sr;
    public obstacleSpawner ospawner;//get obstacle list from the spawner
    public whiteCarSpawner wcspawner;//get white car list from the spawner
    public blackCarSpawner bcspawner;//get black car list from the spawner
    public Startbutton st;
    Vector2 Velo;
    Vector2 grav;
    Vector2 Acc;
    Vector2 wind;
    public bool hitted = false;
    float windspeed;//windspeed
    bool isFalling = true;//check if bird is in the air, bird will be in air by default
    public float speed = 2f;//ad movement speed
    public float health;//start with 3 heart
    public Slider hpvisual;
    public float max = 3;
    public float min = 0f;
    // Start is called before the first frame update
    void Start()
    {
        hpvisual.minValue = 0;
        hpvisual.maxValue = 3;
        hpvisual.value = health;
        sr = GetComponent<SpriteRenderer>();
        Velo = new Vector2(0, 0);
        grav = new Vector2(0, -10f);//dowanward force in y axis
        Acc = new Vector2(0, 5f);//upward force in y
        //wind blow from right to left
    }

    // Update is called once per frame
    void Update()
    {
        
        wind = new Vector2(windspeed, 0);//this needs to be in update so slider can change it
        movement();//call movment & ctrl function
        gotHit();//check for collision
        takedamage(1);
        //reset health if health =0
        if (health == 0)
        {
            st.playagain();
            health = 3;
            hpvisual.value = health;
        }

        //if (hitted)//debug stuff ignore this
        //{
        //    Debug.Log("hitted");
        //    Debug.Log(health);
        //}
    }

    void movement()
    {
        //this is for the player control and bird movement
        //////////////////////////////////////////////////
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);

        //Always apply gravity and wind when falling.
        if (isFalling)
        {
            Velo += (grav + wind) * Time.deltaTime;

        }
        //Debug.Log(Velo);
        //fly movement
        //when player press space bar, add acceleration to give a up force.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Velo = Acc;
            //Debug.Log(Velo.y);
        }
        /////////////////
        //update position
        pos += Velo * Time.deltaTime;

        //AD movement
        //if player press A, bird goes to left
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
        }
        //if player press D, bird goes to right
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }

        ////////////////////////////////////////////////////////////
        //check boundary to prevent bird run ouside the camera space
        ////////////////////////////////////////////////////////////
        float halfwidth = sr.bounds.extents.x;//this is for the size offset so it doesn't completely go outside of screen
        float halfheight = sr.bounds.extents.y;
        //if it exceed the left of screen
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + halfwidth;//stop going out anymore
        }
        //if it exceed the right of screen
        if (screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - halfwidth;//stop going out anymore
        }
        //if it exceed the top of screen
        if (screenpos.y >= Screen.height)
        {
            pos.y = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - halfheight;//stop going out anymore
        }
        //player cannot fly anymore if bird hits the ground.
        if (screenpos.y <= 0)
        {
            float currenty = pos.y;//store current height
            pos.y = currenty;//stay in the same height
            isFalling = false;//not falling anymore so bird stay on the ground
            Velo = Vector2.zero;//clear velocity
        }
        else
        {
            isFalling = true;
        }
        transform.position = pos;
    }

    public void gotHit()
    {
        //This is for checking if player got hit by obstacle or cars
        //I will link this to a hp bar
        /////////////////////////////////
        if (!hitted)//when player did not get hit...
        {
            for (int i = 0; i < ospawner.obstacles.Count; i++)//loop thr obstacle list 
            {
                GameObject obst = ospawner.obstacles[i];
                if (sr.bounds.Contains(obst.transform.position))//if interacting with player sprite
                {
                    
                    Destroy(ospawner.obstacles[i]);//destory the obstacle so player wont keep taking damage until it leaves player sprite bound
                    ospawner.obstacles.Remove(ospawner.obstacles[i]);//remove it from the list.
                    hitted = true;//plaeyr got hit!
                }
            }

            for (int i = 0; i < wcspawner.whitecars.Count; i++)//loop thr white car list
            {
                GameObject wcs = wcspawner.whitecars[i];
                if (sr.bounds.Contains(wcs.transform.position))//if interacting with player sprite
                {
                    Destroy(wcspawner.whitecars[i]);//destory the car so player wont keep taking damage until it leaves player sprite bound
                    wcspawner.whitecars.Remove(wcspawner.whitecars[i]);//remove it from the list.
                    hitted = true;//plaeyr got hit!
                }
            }

            for (int i = 0; i < bcspawner.blackcars.Count; i++)//loop thr black car list
            {
                GameObject bcs = bcspawner.blackcars[i];
                if (sr.bounds.Contains(bcs.transform.position))//if interacting with player sprite
                {
                    Destroy(bcspawner.blackcars[i]);//destory the car so player wont keep taking damage until it leaves player sprite bound
                    bcspawner.blackcars.Remove(bcspawner.blackcars[i]);//remove it from the list.
                    hitted = true;//plaeyr got hit!
                }
            }
        }
        else
        {
            hitted = false;//player is not hitted in other condition
        }

    }

    public void takedamage(float damage)
    {
        //function for hp slider
        if (hitted)//if player got hit...
        {
            health -= damage;//takes the damage 
            hpvisual.value = health;//update healh
            if (health <= hpvisual.minValue)
            {
                health = min;//prevent it goes to negative health
            }
            hitted = false;
        }
    }

    public void windblow(float w)
    {
        windspeed = w;
        //Debug.Log(windspeed);
    }



}
