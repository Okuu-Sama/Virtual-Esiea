using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Custom script used to generate the navmesh of the school
/// </summary>
public class CampusManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject player;

    private NavMeshAgent myNavMeshAgent;


    // Start is called before the first frame update
    void Awake()
    {
        NavMeshSurface s = parent.GetComponent<NavMeshSurface>();
        s.BuildNavMesh(); 
        myNavMeshAgent = player.AddComponent<NavMeshAgent>();
        myNavMeshAgent.radius = 0.15f;
        myNavMeshAgent.speed = 1.5f;
    }
}
