using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    [SerializeField]
    private Transform m_player;

    [SerializeField]
    private Transform m_upFootMarks;

    [SerializeField]
    private Transform m_downFootMarks;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Up()
    {
        m_player.position = new Vector3(m_upFootMarks.position.x, m_upFootMarks.position.y + 1.6f, m_upFootMarks.position.z);
    }

    public void Down()
    {
        m_player.position = new Vector3(m_downFootMarks.position.x, m_downFootMarks.position.y + 1.6f, m_downFootMarks.position.z);
    }
}

