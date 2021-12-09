using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStopScript : MonoBehaviour
{
    public GameObject videoPlayer;
    private VideoPlayerScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = videoPlayer.GetComponent<VideoPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        script.stopVideo();
    }
}
