using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class CampusManager : MonoBehaviour
{

    public GameObject parent;
    public GameObject player;

    private NavMeshAgent myNavMeshAgent;


    // Start is called before the first frame update
    void Awake()
    {
        //player.transform.localPosition = new Vector3(-33.76f, 4.1f, -14.5f);
        NavMeshSurface s = parent.GetComponent<NavMeshSurface>();
        s.BuildNavMesh(); 
        myNavMeshAgent = player.AddComponent<NavMeshAgent>();
        myNavMeshAgent.radius = 0.15f;
        myNavMeshAgent.speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
