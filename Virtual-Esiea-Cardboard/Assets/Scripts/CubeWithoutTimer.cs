using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWithoutTimer : MonoBehaviour
{
    private Renderer m_cubeRenderer;
    private Color m_defaultColor;
    private Color m_black;


    private void Start()
    {
        m_cubeRenderer = gameObject.GetComponent<Renderer>();
        m_defaultColor = m_cubeRenderer.material.color;
        m_black = Color.black;
        ChangeCubeRenderer(false);
    }

    public void OnPointerEnter()
    {
        ChangeCubeRenderer(true);
    }

    public void OnPointerExit()
    {
        ChangeCubeRenderer(false);
    }

    private void ChangeCubeRenderer(bool gazedAt)
    {
        m_cubeRenderer.material.color = gazedAt ? m_black : m_defaultColor;
    }
}