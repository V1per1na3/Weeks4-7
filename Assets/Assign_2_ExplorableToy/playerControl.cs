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
    bool isFalling = true;
    public float speed = 2f;//ad movement speed
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Velo = new Vector2(0, 0);
        grav = new Vector2(0, -0.02f);//dowanward force in y axis
        Acc = new Vector2(0, 7f);//upward force in y
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        
        //Always apply gravity when falling.
        if (isFalling)
        {
            Velo += grav;
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
        float halfwidth = sr.bounds.extents.x;
        float halfheight = sr.bounds.extents.y;
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + halfwidth;
        }
        if (screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - halfwidth;
        }
        if(screenpos.y >= Screen.height)
        {
            pos.y = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y-halfheight;
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
