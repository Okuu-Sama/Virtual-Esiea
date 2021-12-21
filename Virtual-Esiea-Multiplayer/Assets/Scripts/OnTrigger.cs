using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnTrigger : MonoBehaviour
{
    private AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            m_audioSource.Play();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            m_audioSource.Pause();
        }
    }
}
