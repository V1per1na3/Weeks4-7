using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackpoopMovement : MonoBehaviour
{
    //this script is for all blackpoop elements
    //poop will drop from player position and fall (decrease in y)
    //check if this black poop drops on a white car (lmao)
    //if it does, destory the white car!
    SpriteRenderer srb;
    public bool hitcar = false;
    public float speed = 8f;
    public bool poop = false;
    public blackPoopSpawner spawner;//this is the spawner
    public whiteCarSpawner wcspawner;//get white car list from the spawner
    public Score sc;//score script needs to know when collision happen to add score since detection function is here
   

    // Start is called before the first frame update
    void Start()
    {
        srb = GetComponent<SpriteRenderer>();//need sprite size for collision check 
    }

    // Update is called once per frame
    void Update()
    {

        if (poop)//drop poop only when its pooping
        {
            dropPoop();//call drop poop function
            poopOnWhiteCar();//check if it lands on a white car?
        }

        //if (hitcar)
        //{
        //    Debug.Log("ewww");
        //}

    }

    public void dropPoop()
    {
        //drop the poop! 
        Vector2 pos = transform.position;
        pos.y -= speed * Time.deltaTime;//drop from bird position and falls down
        transform.position = pos;
    }

    public void poopOnWhiteCar()
    {
        //check if it poop on a white car

        for (int i = 0; i < wcspawner.whitecars.Count; i++)//loop thr the list of spawned white car
        {
           GameObject wc = wcspawner.whitecars[i];
            if (srb.bounds.Contains(wc.transform.position))//if they overlap
            {
                sc.mb = this;
                hitcar = true;//ewwww the pop hits the car, set to true
                Destroy(wcspawner.whitecars[i]);//destory the car after it got hit so player can't hit it again
                wcspawner.whitecars.Remove(wcspawner.whitecars[i]);//remove it from the list.
            }
        }

    }
}
