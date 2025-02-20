using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Startbutton : MonoBehaviour
{
    //start game script
    public GameObject bg;
    public Score tt;
    public GameObject start;
    public GameObject bird;
    public GameObject obstspawer;
    public GameObject score;
    public GameObject blackpoopbutton;
    public GameObject whitepoopbutton;
    public GameObject blpoopbTimer;
    public GameObject whpoopbTimer;
    public GameObject gameavatardropdown;
    public GameObject windsliderimg1;
    public GameObject windsliderimg2;
    public GameObject windsliderimg3;
    public GameObject dropdown1;
    public GameObject dropdown2;
    public TextMeshProUGUI text;
    public bool wantoplayagain = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgame()
    {
        //when trigger button, set all ingameUi to true,
        //hide character dropdown and wind slider bc they still effect ingame stuff
        //set start button itself to false;
        bg.SetActive(false);
        windsliderimg1.SetActive(false);
        windsliderimg2.SetActive(false);
        windsliderimg3.SetActive(false);
        bird.SetActive(true);
        obstspawer.SetActive(true);
        blackpoopbutton.SetActive(true);
        whitepoopbutton.SetActive(true);
        score.SetActive(true);
        blpoopbTimer.SetActive(true);
        whpoopbTimer.SetActive(true);
        dropdown1.SetActive(false);
        dropdown2.SetActive(false);
        text.gameObject.SetActive(false);
        start.SetActive(false);

    }

    public void playagain()
    {
        //reset score
        tt.scorevalue = 0f;
        tt.score.text = tt.scorevalue.ToString();
        //default all ingame stuff set to false
        //all startgame ui set to true;
        bg.SetActive(true);
        bird.SetActive(false);
        obstspawer.SetActive(false);
        blackpoopbutton.SetActive(false);
        whitepoopbutton.SetActive(false);
        score.SetActive(false);
        blpoopbTimer.SetActive(false);
        whpoopbTimer.SetActive(false);
        windsliderimg1.SetActive(true);
        windsliderimg2.SetActive(true);
        windsliderimg3.SetActive(true);
        dropdown1.SetActive(true);
        dropdown2.SetActive(true);
        text.gameObject.SetActive(true);
        start.SetActive(true);
    }
}
