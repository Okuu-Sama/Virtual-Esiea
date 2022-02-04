using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkCommandLine : MonoBehaviour
{
    private string line;
    void Start()
    {

        if(Application.isBatchMode)
        {
            SceneManager.LoadScene("ServerTest");
        }
        if (Application.isEditor) return;
    }
}