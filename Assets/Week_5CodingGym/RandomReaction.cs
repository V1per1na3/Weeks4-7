using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomReaction : MonoBehaviour
{
    public SpriteRenderer sp;
    public Sprite[] react;
    public bool closeEnough=true;


    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (closeEnough)
        {
            sp.sprite = react[Random.Range(0, react.Length)];
            


        }
    }
}
