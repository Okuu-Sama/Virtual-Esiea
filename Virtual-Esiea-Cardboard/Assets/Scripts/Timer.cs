using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image m_timerCharger;

    [SerializeField]
    private float m_activeDuration;
    private float m_remainingTime;
    private bool m_activeTimer;

    private void Start()
    {
        m_timerCharger.fillAmount = 0.0f;
        m_remainingTime = 0.0f;
    }

    public bool IsActive
    {
        get { return m_remainingTime <= 0 ? true : false; }
    }

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

    public void Activate()
    {
        m_activeTimer = true;
        m_remainingTime = m_activeDuration;
    }

    public void NullTimerCharger()
    {
        m_activeTimer = false;
        m_timerCharger.fillAmount = 0.0f;
    }
}