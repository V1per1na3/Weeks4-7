using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whitepoopMovement : MonoBehaviour
{
    //this script is for all whitepoop elements
    //poop will drop from player position and fall (decrease in y)
    //check if this white poop drops on a black car (lmao)
    //if it does, destory the black car!
    SpriteRenderer srw;
    public bool hitcar = false;
    public float speed = 8f;
    public bool poop = false;
    public whitePoopSpawner spawner;//this is the spawner
    public blackCarSpawner bcspawner;//get black car list from the spawner
    public Score sc;//score script needs to know when collision happen to add score since detection function is here

    // Start is called before the first frame update
    void Start()
    {
        srw = GetComponent<SpriteRenderer>();//need sprite size for collision check
    }

    // Update is called once per frame
    void Update()
    {
        if (poop)//drop poop only when its pooping
        {
            dropPoop();//call drop poop function
            poopOnblackCar();//check if it lands on a black car?
        }
    }

    public void dropPoop()
    {
        //drop the poop! 
        Vector2 pos = transform.position;
        pos.y -= speed * Time.deltaTime;//drop from bird position and falls down
        transform.position = pos;
    }

    public void poopOnblackCar()
    {
        //check if it poop on a black car

        for (int i = 0; i < bcspawner.blackcars.Count; i++)//loop thr the list of spawned black car
        {
            GameObject bc = bcspawner.blackcars[i];
            if (srw.bounds.Contains(bc.transform.position))//if they overlap
            {
                sc.wm = this;
                hitcar = true;//ewwww the pop hits the car, set to true
                Destroy(bcspawner.blackcars[i]);//destory the car after it got hit so player can't hit it again
                bcspawner.blackcars.Remove(bcspawner.blackcars[i]);//remove it from the list.
            }
        }

    }
}
