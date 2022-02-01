using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// Gaze filling image
    /// </summary>
    [SerializeField]
    private Image m_timerCharger;

    /// <summary>
    /// Timer duration in second
    /// </summary>
    [SerializeField]
    private float m_activeDuration;
    private float m_remainingTime;
    private bool m_activeTimer;

    private void Start()
    {
        m_timerCharger.fillAmount = 0.0f;
        m_remainingTime = 0.0f;
    }

    /// <summary>
    /// Check if timer is finished or not
    /// </summary>
    public bool IsActive
    {
        get { return m_remainingTime <= 0 ? true : false; }
    }

    /// <summary>
    /// Each frame implement the timer by decreasing m_activeDuration value
    /// </summary>
    void Update()
    {
        if (m_remainingTime > 0 && m_activeTimer)
        {
            m_remainingTime -= Time.deltaTime;
            m_timerCharger.fillAmount = m_activeDuration - m_remainingTime;
        }
        else
            NullTimerCharger();
    }

    /// <summary>
    /// Activate the timer
    /// </summary>
    public void Activate()
    {
        m_activeTimer = true;
        m_remainingTime = m_activeDuration;
    }

    /// <summary>
    /// Put the fill image to 0
    /// </summary>
    public void NullTimerCharger()
    {
        m_activeTimer = false;
        m_timerCharger.fillAmount = 0.0f;
    }
}