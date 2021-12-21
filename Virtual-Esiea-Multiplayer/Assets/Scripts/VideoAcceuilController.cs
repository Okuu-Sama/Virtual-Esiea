using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;



public class VideoAcceuilController : MonoBehaviour
{

    public VideoPlayer Vp;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        Vp.Pause();
        txt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Vp.time.ToString("000"));
        double seconds1 = Vp.time;
        double minutes1;
        if (Vp.time > 60)
        {
            minutes1 = Vp.time / 60;
        } else
        {
            minutes1 = 0.0;
        }
        //Debug.Log(minutes1 + ":" + seconds1);
        double seconds2 = Vp.clip.length;
        double minutes2;
        if (Vp.clip.length > 60)
        {
            minutes2 = Vp.clip.length / 60;
            seconds2 = seconds2 - Convert.ToInt32(minutes2) * 60;
        }
        else
        {
            minutes2 = 0.0;
        }
        txt.text = minutes1.ToString("00") + ":" + seconds1.ToString("00") + "/" + minutes2.ToString("00") + ":" + seconds2.ToString("00");
        //t2 = Vp.clip.length * 24f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vp.isPaused)
            {
                Vp.Play();
                txt.enabled = true;
            }

            else
            {
                Vp.Pause();
                txt.enabled = false;
            }
        } 
    }
}
