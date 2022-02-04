using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Unity.Netcode;

public class PlayerController : MonoBehaviour
{

    public GameObject player = null;
    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private float m_RotationSpeed;

    private NavMeshAgent myNavMeshAgent;

    //The current local player
    private Server.DefaultPlayer defaultPlayer = null;

    private Quaternion playerLocalRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        if(player is null)
        {
            player = gameObject;
        }
        myNavMeshAgent = player.GetComponent<NavMeshAgent>();

        m_Speed = 0.1f;
        m_RotationSpeed = 1.0f;

        //We find the instance of the client player
        if(gameObject.tag == "NetworkPlayer")
        {
            defaultPlayer = gameObject.GetComponent<Server.DefaultPlayer>();
        }

        //In case we couldn't initialize the navmeshagent for the local client
        if(gameObject.GetComponent<NavMeshAgent>() is null)
        {
            myNavMeshAgent = gameObject.AddComponent<NavMeshAgent>();
            myNavMeshAgent.speed += 0.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //The player is moving forward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gameObject.tag == "NetworkPlayer")
            {
                Vector3 temp = myNavMeshAgent.velocity + (transform.forward * Time.deltaTime);

                defaultPlayer.Move(temp);
            }
        }

        //The player is rotating to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(new Vector3(0.0f, m_RotationSpeed, 0.0f));
            playerLocalRotation = player.transform.rotation;
            defaultPlayer.Rotate(playerLocalRotation);
        }

        //The player is rotating to the left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(new Vector3(0.0f, -m_RotationSpeed, 0.0f));
            playerLocalRotation = player.transform.rotation;
            defaultPlayer.Rotate(playerLocalRotation);
        }

        //The player is moving backward
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            if (gameObject.tag == "NetworkPlayer")
            {
                Vector3 tempback = myNavMeshAgent.velocity + (-transform.forward * Time.deltaTime);
                defaultPlayer.Move(tempback);
            }
        }
    }
}
