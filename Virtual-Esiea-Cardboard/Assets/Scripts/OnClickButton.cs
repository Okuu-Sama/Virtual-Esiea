using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{
    [SerializeField]
    private Transform m_player;

    [SerializeField]
    private Transform m_lobbyFootMarks;

    [SerializeField]
    private Transform m_CDIFootMarks;

    [SerializeField]
    private Transform m_languageLabFootMarks;

    [SerializeField]
    private Transform m_informaticLabFootMarks;

    [SerializeField]
    private Transform m_electronicLabFootMarks;

    [SerializeField]
    private Transform m_room115FootMarks;

    [SerializeField]
    private Transform m_CafetAssosFootMarks;

    private float m_playerSize;

    // Start is called before the first frame update
    void Start()
    {
        m_playerSize = 1.6f;
    }

    public void Lobby()
    {
        //m_player.position = new Vector3(-32.5f, 4.9f, -19.5f);
        m_player.position = new Vector3(m_lobbyFootMarks.position.x, m_lobbyFootMarks.position.y + m_playerSize, m_lobbyFootMarks.position.z);
    }

    public void CDI()
    {
        m_player.position = new Vector3(m_CDIFootMarks.position.x, m_CDIFootMarks.position.y + m_playerSize, m_CDIFootMarks.position.z);
    }

    public void LanguageLab()
    {
        m_player.position = new Vector3(m_languageLabFootMarks.position.x, m_languageLabFootMarks.position.y + m_playerSize, m_languageLabFootMarks.position.z);
    }

    public void InformaticLab()
    {
        m_player.position = new Vector3(m_informaticLabFootMarks.position.x, m_informaticLabFootMarks.position.y + m_playerSize, m_informaticLabFootMarks.position.z);
    }

    //public void InformaticLab2()
    //{
    //    m_player.position = new Vector3(5.5f, 4.92f, 11.25f);
    //}

    public void ElectronicLab()
    {
        m_player.position = new Vector3(m_electronicLabFootMarks.position.x, m_electronicLabFootMarks.position.y + m_playerSize, m_electronicLabFootMarks.position.z);
    }

    public void Room115()
    {
        m_player.position = new Vector3(m_room115FootMarks.position.x, m_room115FootMarks.position.y + m_playerSize, m_room115FootMarks.position.z);
    }

    public void CafetAssos()
    {
        m_player.position = new Vector3(m_CafetAssosFootMarks.position.x, m_CafetAssosFootMarks.position.y + m_playerSize, m_CafetAssosFootMarks.position.z);
    }

}
