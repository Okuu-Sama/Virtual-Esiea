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
    private Server.DefaultPlayer defaultPlayer = null;
    private Vector3 playerLocalMovement = Vector3.zero;
    private Quaternion playerLocalRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Cube");

        //TODO CHANGER RECUP DU PLAYER

        if(player is null)
        {
            player = gameObject;
        }
        myNavMeshAgent = player.GetComponent<NavMeshAgent>();
        m_Speed = 0.1f;
        m_RotationSpeed = 1.0f;
        if(gameObject.tag == "NetworkPlayer")
        {
            defaultPlayer = gameObject.GetComponent<Server.DefaultPlayer>();
            //defaultPlayer.Move(gameObject.transform.position);
            Debug.Log("changed network variable content in playercontroller script");
        }
        if(gameObject.GetComponent<NavMeshAgent>() is null)
        {
            myNavMeshAgent = gameObject.AddComponent<NavMeshAgent>();
            myNavMeshAgent.speed += 3;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("pos on x: " + gameObject.transform.position.x + 
                "\n pos on y: " + gameObject.transform.position.y +
                "\n pos on z: " + gameObject.transform.position.z);
        Debug.Log((gameObject.transform.localPosition).ToString("F4"));
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            Debug.Log("player is moving forward");
            /*ulong localclientId = NetworkManager.Singleton.LocalClientId;
            NetworkClient thisclient = null;
            thisclient = Server.ServerManager.GetNetworkClient(localclientId);
            if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(localclientId, out NetworkClient networkClient))
            {
                Debug.Log("failed retreiving local client");
            }
            else
            {
                Debug.Log("Successfully got client");
            }

            if (!networkClient.PlayerObject.TryGetComponent<Server.DefaultPlayer>(out var localdefaultPlayer))
            {
                Debug.Log("failed retreiving client player object");
            }

            localdefaultPlayer.Move(thisclient.PlayerObject.transform.position + (myNavMeshAgent.velocity + (transform.forward * Time.deltaTime)));
            */


                //myNavMeshAgent.velocity += player.transform.forward * m_Speed;
                //Vector3 forwardmovement = player.transform.forward * m_Speed;
                //playerLocalMovement = new Vector3(myNavMeshAgent.velocity.x, myNavMeshAgent.velocity.y, myNavMeshAgent.velocity.z);
                //Debug.Log(myNavMeshAgent.velocity.z);
            if (gameObject.tag == "NetworkPlayer")
            {
                
                Debug.Log(myNavMeshAgent.velocity);
                Debug.Log(myNavMeshAgent.velocity);
                //myNavMeshAgent.Move(transform.forward * Time.deltaTime);
                Vector3 temp = myNavMeshAgent.velocity + (transform.forward * Time.deltaTime);
                Debug.Log(temp.ToString("F3"));
                Debug.Log(transform.position + temp);
                defaultPlayer.Move(temp);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(new Vector3(0.0f, m_RotationSpeed, 0.0f));
            playerLocalRotation = player.transform.rotation;
            defaultPlayer.Rotate(playerLocalRotation);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(new Vector3(0.0f, -m_RotationSpeed, 0.0f));
            playerLocalRotation = player.transform.rotation;
            defaultPlayer.Rotate(playerLocalRotation);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //myNavMeshAgent.velocity -= player.transform.forward * m_Speed;
            //playerLocalMovement = new Vector3(myNavMeshAgent.velocity.x, myNavMeshAgent.velocity.y, myNavMeshAgent.velocity.z);
            if (gameObject.tag == "NetworkPlayer")
            {
                //myNavMeshAgent.Move(-transform.forward * Time.deltaTime);
                defaultPlayer.Move(-transform.forward * Time.deltaTime);
            }
        }
    }
}
