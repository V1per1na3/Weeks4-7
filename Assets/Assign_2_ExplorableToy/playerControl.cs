using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    //this script is for bird (player avatar) movement. bird will be always falling if its in the air
    //player can hit space bar to flap (fly) and use A and D to control left and right
    //if the bird hits the ground player cannot fly anymore. this will link to lose condition
    SpriteRenderer sr;

    Vector2 Velo;
    Vector2 grav;
    Vector2 Acc;
    Vector2 wind;
    public float windspeed =0.001f;//windspeed
    bool isFalling = true;//check if bird is in the air, bird will be in air by default
    public float speed = 2f;//ad movement speed
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Velo = new Vector2(0, 0);
        grav = new Vector2(0, -0.05f);//dowanward force in y axis
        Acc = new Vector2(0, 5f);//upward force in y
        wind = new Vector2(windspeed, 0);//wind blow from right to left
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        
        //Always apply gravity when falling.
        if (isFalling)
        {
            Velo += grav+wind;
            
        }

        //fly movement
        //when player press space bar, add acceleration to give a up force.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Velo = Acc;
            //Debug.Log(Velo.y);
        }
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

        //check boundary to prevent bird run ouside the camera space
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
            pos.y = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y-halfheight;//stop going out anymore
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
}
