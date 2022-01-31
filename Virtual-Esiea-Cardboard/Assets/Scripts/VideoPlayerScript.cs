using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    /// <summary>
    /// //Script to manage a video player component from a footmark
    /// </summary>

    //Video Screen which contains the VideoPlayer object to manage
    [SerializeField]
    private GameObject videoScreen =null;

    //Transform of the player of the scene
    [SerializeField]
    private Transform m_player = null;

    //VideoPlayer object to manage
    private VideoPlayer videoPlayer = null;

    void Start()
    {
        videoPlayer = videoScreen.GetComponent<UnityEngine.Video.VideoPlayer>();

    }

    /// <summary>
    /// Method to play the video associated to the VideoPlayer
    /// </summary>
    public void playVideo()
    {
        videoPlayer.Play();
    }

    /// <summary>
    /// Method to stop the video associated to the VideoPlayer
    /// </summary>
    public void stopVideo()
    {
        videoPlayer.Stop();
    }

    void Update() {
        //If the player is on the footmark linked to the VideoPlayer
        if (m_player.position.x ==transform.position.x && m_player.position.z == transform.position.z) {

            playVideo();

        }
        else
        {
            stopVideo();
        }
    }
}
