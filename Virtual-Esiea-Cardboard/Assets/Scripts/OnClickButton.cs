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

    public void LobbyRight()
    {
        m_player.position = new Vector3(-30.0f, 4.91f, -23.0f);
    }

}
