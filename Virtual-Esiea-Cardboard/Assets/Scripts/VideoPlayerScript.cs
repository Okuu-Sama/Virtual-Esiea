using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject videoScreen;
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = videoScreen.GetComponent<UnityEngine.Video.VideoPlayer>();
        
    }

    public void playVideo() 
    {
        videoPlayer.Play();
    }

    public void stopVideo() 
    {
        videoPlayer.Stop();
    }

}
