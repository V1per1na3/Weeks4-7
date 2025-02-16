using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dropDownEasy : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer mysprite;
    public Sprite newItemSprite;


    private void Start()
    {
        mysprite.sprite = dropdown.options[0].image;
    }
    public void valuechange(int index)
    {
        Debug.Log (dropdown.options[index].text);
        mysprite.sprite = dropdown.options[index].image;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData("NewThing!", newItemSprite);
            dropdown.options.Add(item);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (dropdown.options.Count > 0)
            {
                dropdown.options.RemoveAt(dropdown.options.Count - 1);//remove the last one from the list
            }
           
        }
    }
}
