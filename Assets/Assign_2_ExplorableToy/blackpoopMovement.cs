using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackpoopMovement : MonoBehaviour
{
    SpriteRenderer srb;
    public bool hitcar = false;
    public float speed = 8f;
    public bool poop = false;
    public blackPoopSpawner spawner;
    public whiteCarSpawner wcspawner;//get white car list from the spawner
   

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
            dropPoop();
            poopOnWhiteCar();
        }

        if (hitcar)
        {
            Debug.Log("ewww");
        }

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

        for (int i = 0; i < wcspawner.whitecars.Count; i++)
        {
           GameObject wc = wcspawner.whitecars[i];
            if (srb.bounds.Contains(wc.transform.position))
            {
                Destroy(wcspawner.whitecars[i]);//destory the car so player wont keep taking damage until it leaves player sprite bound
                wcspawner.whitecars.Remove(wcspawner.whitecars[i]);//remove it from the list.
                hitcar = true;
            }
        }

    }
}
