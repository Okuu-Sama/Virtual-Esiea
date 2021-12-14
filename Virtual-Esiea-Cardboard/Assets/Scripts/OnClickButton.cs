using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{
    [SerializeField]
    private Transform m_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Lobby()
    {
        m_player.position = new Vector3(-32.5f, 4.9f, -19.5f);
    }

    public void CDI()
    {
        m_player.position = new Vector3(-4.25f, 4.87f, -18.0f);
    }

    public void LanguageLab()
    {
        m_player.position = new Vector3(8.7f, 4.88f, -2.8f);
    }

    public void InformaticLab1()
    {
        m_player.position = new Vector3(-1.6f, 4.95f, 17.5f);
    }

    public void InformaticLab2()
    {
        m_player.position = new Vector3(5.5f, 4.92f, 11.25f);
    }

    public void ElectronicLab()
    {
        m_player.position = new Vector3(-15.8f, 4.96f, 11.13f);
    }

    public void Room115()
    {
        m_player.position = new Vector3(23.8f, 9.25f, 15.0f);
    }

    public void CafetAssos()
    {
        m_player.position = new Vector3(4.56f, 1.64f, 8.0f);
    }

}
