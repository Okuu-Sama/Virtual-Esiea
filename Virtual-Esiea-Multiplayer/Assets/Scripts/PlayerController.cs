using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private float m_RotationSpeed;

    private NavMeshAgent myNavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Cube");
        myNavMeshAgent = player.GetComponent<NavMeshAgent>();
        m_Speed = 0.01f;
        m_RotationSpeed = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myNavMeshAgent.velocity += player.transform.forward * m_Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(new Vector3(0.0f, m_RotationSpeed, 0.0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(new Vector3(0.0f, -m_RotationSpeed, 0.0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            myNavMeshAgent.velocity -= player.transform.forward * m_Speed;
        }
    }
}
