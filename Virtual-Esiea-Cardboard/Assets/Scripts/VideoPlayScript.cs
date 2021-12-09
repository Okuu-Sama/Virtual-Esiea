using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayScript : MonoBehaviour
{
    private bool m_watch;
    [SerializeField]
    private Timer timer = new Timer();
    [SerializeField]
    private GameObject videoPlayer;
    private VideoPlayerScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = videoPlayer.GetComponent<VideoPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.IsActive && m_watch == true)
        {
            script.playVideo();
        }

    }

    public void OnPointerEnter()
    {
        m_watch = true;
        timer.Activate();
        
    }

    public void OnPointerExit()
    {
        m_watch = false;

    }
}
