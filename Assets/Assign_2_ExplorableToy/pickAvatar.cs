using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pickAvatar : MonoBehaviour
{
    //this script is for picking player avatar sprite
    // Start is called before the first frame update
    public TMP_Dropdown dropdown;
    public SpriteRenderer mysprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change(int index)
    {
        mysprite.sprite = dropdown.options[index].image;
    }
}
