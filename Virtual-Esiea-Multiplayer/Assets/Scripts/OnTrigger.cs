using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnTrigger : MonoBehaviour
{
    private AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter (Collider collider)
    {
        Debug.Log("reached Ontrigger");
        if (collider.gameObject.tag == "NetworkPlayer")
        {
            Debug.Log("Player reached the audio zone");
            m_audioSource.Play();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "NetworkPlayer")
        {
            m_audioSource.Pause();
        }
    }
}
