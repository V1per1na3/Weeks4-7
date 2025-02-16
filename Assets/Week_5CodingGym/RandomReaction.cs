using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomReaction : MonoBehaviour
{
    public GameObject speechbubble;
    public Image speechbubbleimg;
    public SpriteRenderer sr;
    public Transform burger;
    public bool ischanged = false;//has the sprite changed?
    public Sprite[] sp;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        speechbubble.SetActive(false);//hide canvas initially
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.bounds.Contains(burger.position))//check if burger is within player sprite bound
        {
            speechbubble.SetActive(true);//show speechbubble if is closeenough
            randomreaction();
        }
        else
        {
            speechbubble.SetActive(false);//turn it off otherwise
            ischanged = false;//reset condition
        }

    }

    void randomreaction()
    {
        if (!ischanged)//if its not been changed, change it!
        {
            int Index = Random.Range(0, sp.Length);
            speechbubbleimg.sprite = sp[Index];
            ischanged = true;
        }

    }

    
}
