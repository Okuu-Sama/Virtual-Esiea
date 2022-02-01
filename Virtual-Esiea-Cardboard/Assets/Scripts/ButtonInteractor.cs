using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractor : MonoBehaviour
{
    /// <summary>
    /// Is use to know if we are looking an interactable gameObject 
    /// </summary>
    private bool m_watch;

    [SerializeField]
    private Timer m_timer;

    /// <summary>
    /// Call a public method by interating with the button 
    /// </summary>
    [SerializeField]
    private UnityEvent click;

    void Start()
    {
        m_watch = false;
    }

    /// <summary>
    /// If timer is finished and user is looking at a button a method is called by UnityEvent
    /// </summary>
    void Update()
    {
        if (m_timer.IsActive && m_watch == true)
        {
            click.Invoke();
        }
    }

    /// <summary>
    /// Called by cameraPointer script to know if we are looking at a button
    /// </summary>
    public void OnPointerEnter()
    {
        m_watch = true;
        m_timer.Activate();
    }

    /// <summary>
    /// Called by cameraPointer script to know if we are not looking at a button
    /// </summary>
    public void OnPointerExit()
    {
        m_watch = false;
        m_timer.NullTimerCharger();
    }
}
