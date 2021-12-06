using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float m_activeDuration;
    private float m_remainingTime = 0.0f;

    public bool IsActive
    {
        get { return m_remainingTime <= 0 ? true : false; }
    }

    void Update()
    {
        if (m_remainingTime > 0)
            m_remainingTime -= Time.deltaTime;
    }

    public void Activate()
    {
        m_remainingTime = m_activeDuration;
    }
}
