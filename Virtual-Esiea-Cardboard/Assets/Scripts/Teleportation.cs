using UnityEngine;

public class Teleportation : MonoBehaviour
{
    /// <summary>
    /// Is use to know if we are looking an interactable gameObject 
    /// </summary>
    private bool m_watch;

    /// <summary>
    /// Actual position of the user
    /// </summary>
    private Vector3 m_actualPosition;

    /// <summary>
    /// position of the gazed mark on the floor 
    /// </summary>
    private Vector3 m_newPosition;

    [SerializeField]
    private Timer m_timer;

    /// <summary>
    /// User
    /// </summary>
    [SerializeField]
    private Transform m_player;



    private void Start()
    {
        m_watch = false;
        m_actualPosition = m_player.position;
        m_newPosition = Vector3.zero;
        TeleportPlayer(m_watch);
    }

    /// <summary>
    /// If timer is finished and user is looking at a mark the user is teleported on this mark
    /// </summary>
    private void Update()
    {
        if (m_timer.IsActive && m_watch == true)
        {
            TeleportPlayer(m_watch);
        }
    }

    /// <summary>
    /// Called by cameraPointer script to know if we are looking at an interactable gameObbject
    /// </summary>
    public void OnPointerEnter()
    {
        m_watch = true;
        m_newPosition = new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z);
        m_timer.Activate();
    }

    /// <summary>
    /// Called by cameraPointer script to know if we are not looking at an interactable gameObbject
    /// </summary>
    public void OnPointerExit()
    {
        m_watch = false;
        m_timer.NullTimerCharger();
        m_actualPosition = m_player.position;
        TeleportPlayer(m_watch);
    }

    /// <summary>
    /// Define if the new position will be the same or not
    /// </summary>
    /// <param name="gazedAt"></param>
    private void TeleportPlayer(bool gazedAt)
    {
        m_player.position = gazedAt ? m_newPosition : m_actualPosition;
    }
}