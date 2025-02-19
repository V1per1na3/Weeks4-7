using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMER : MonoBehaviour
{
    //this script is a timer that control countdown time of poop button
    //interactable time. so player cannot poop continously...lmao
    public Button poopbuttons;
    public Slider sildertimer;
    public float cooldowntime=1f;
    public float colldowntimer=0f;
    bool cooldowned = false;
    
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        sildertimer.maxValue = cooldowntime;
        sildertimer.value = cooldowntime;//start with full time
        poopbuttons.interactable = true;//button is initially set to interactive
        poopbuttons.image.enabled = true;//image visible
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldowned)//during cooldown
        {
            colldowntimer -= Time.deltaTime;//countdown timer
            sildertimer.value = colldowntimer;

            if (colldowntimer <= 0)//if timer count down to 0
            {
                cooldowned = false;//stop cooldown
                poopbuttons.interactable = true;//interative again
                poopbuttons.image.enabled = true;//image visible
                sildertimer.value = cooldowntime;//reset silder
            }
        }
    }

    public void startcooldown()
    {
        //this will link to poop button
        //if player click the poop button and it's not coolingdown
        if (!cooldowned)
        {
            cooldowned = true;//start cooldown
            colldowntimer = cooldowntime;
            sildertimer.value = cooldowntime;//assgin cooldown time to silder value
            poopbuttons.interactable = false;//nope you are not allow to poop.
            poopbuttons.image.enabled = false;//image invisible

        }
    }
}
