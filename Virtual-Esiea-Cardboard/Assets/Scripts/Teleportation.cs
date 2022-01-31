using UnityEngine;
using UnityEngine.Video;

public class Teleportation : MonoBehaviour
{
    private bool m_watch;
    private Vector3 m_actualPosition;
    private Vector3 m_newPosition;
    [SerializeField]
    private Timer m_timer;

    [SerializeField]
    private Transform m_player;
    


    private void Start()
    {
        m_watch = false;
        m_actualPosition = m_player.position;
        m_newPosition = Vector3.zero;
        TeleportPlayer(m_watch);

    }
    private void Update()
    {
        if (m_timer.IsActive && m_watch == true)
        {
            TeleportPlayer(m_watch);
        }
    }
    public void OnPointerEnter()
    {
        m_watch = true;
        m_newPosition = new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z);
        m_timer.Activate();


    }
    public void OnPointerExit()
    {
        m_watch = false;
        m_timer.NullTimerCharger();
        m_actualPosition = m_player.position;
        TeleportPlayer(m_watch);

    }
    private void TeleportPlayer(bool gazedAt)
    {
        m_player.position = gazedAt ? m_newPosition : m_actualPosition;
    }
}