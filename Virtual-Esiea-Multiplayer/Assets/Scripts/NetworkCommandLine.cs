using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Custom script to handle the server started as a CLI
/// Ref. Project Documentation
/// </summary>
public class NetworkCommandLine : MonoBehaviour
{
    private string line;
    void Start()
    {
        if(Application.isBatchMode)
        {
            SceneManager.LoadScene("Multiplayer");
        }
        if (Application.isEditor) return;
    }
}