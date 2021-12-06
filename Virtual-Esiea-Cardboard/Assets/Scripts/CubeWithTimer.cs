using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWithTimer : MonoBehaviour
{
    private Renderer m_cubeRenderer;
    private Color m_defaultColor;
    private Color m_yellow;
    private bool m_watch;

    [SerializeField]
    private Timer m_timer = new Timer();

    private void Start()
    {
        m_cubeRenderer = gameObject.GetComponent<Renderer>();
        m_defaultColor = m_cubeRenderer.material.color;
        m_yellow = Color.yellow;
        m_watch = false;
        ChangeCubeRenderer(false);
    }
    private void Update()
    {
        if (m_timer.IsActive && m_watch == true)
        {
            ChangeCubeRenderer(true);
        }
    }
    public void OnPointerEnter()
    {
        m_watch = true;
        m_timer.Activate();
    }
    public void OnPointerExit()
    {
        m_watch = false;
        ChangeCubeRenderer(false);
    }
    private void ChangeCubeRenderer(bool gazedAt)
    {
        m_cubeRenderer.material.color = gazedAt ? m_yellow : m_defaultColor;
    }
}
