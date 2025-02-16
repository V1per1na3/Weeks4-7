using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class changebullet : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer bulletsprite;
    // Start is called before the first frame update
    void Start()
    {
        bulletsprite.sprite = dropdown.options[0].image;//start with the first sprite
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChanged(int index)
    {
        bulletsprite.sprite = dropdown.options[index].image;//change sprite base on list number
    }
}
