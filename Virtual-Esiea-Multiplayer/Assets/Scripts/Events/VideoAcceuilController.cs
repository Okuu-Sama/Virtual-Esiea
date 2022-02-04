using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;


/// <summary>
/// Custom script to control a video player on a certain gameobject
/// </summary>
public class VideoAcceuilController : MonoBehaviour
{
    //The video player to control
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

        //Display the time of the video
        double seconds1 = Vp.time;
        double minutes1;
        if (Vp.time > 60)
        {
            minutes1 = Vp.time / 60;
        } else
        {
            minutes1 = 0.0;
        }

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

        //We can pause and play the video using the space key
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
