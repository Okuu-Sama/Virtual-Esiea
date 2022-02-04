using Unity.Netcode;
using UnityEngine;
using TMPro;

namespace Server
{
    public class ServerManager : MonoBehaviour
    {
        //The Text input area for the chat
        [SerializeField] private TMP_InputField input = null;

        //TODO: Make list of connected user

        //Spawn a custom GUI to launch the network service
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            {
                StartButtons();
            }
            else
            {
                StatusLabels();

                SubmitNewPosition();
            }

            GUILayout.EndArea();
        }

        static void StartButtons()
        {
            if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
            if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
        }

        //Show the status of the current instance of the program. Is a server or client?
        static void StatusLabels()
        {
            var mode = NetworkManager.Singleton.IsHost ?
                "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

            GUILayout.Label("Transport: " +
                NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
        }

        /// <summary>
        /// Custom function to help the client teleport back to the spawn (entrance of the school).
        /// </summary>
        static void SubmitNewPosition()
        {
            if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Move" : "Request Position Change"))
            {
                var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
                var player = playerObject.GetComponent<DefaultPlayer>();
                GameObject playerspawn = GameObject.Find("PlayerSpawn");
                player.Move(playerspawn.transform.position);
            }
        }

        /// <summary>
        /// Retrieve the message in the input area of the local client and send it to the server
        /// </summary>
        /// <param name="message"></param>
        public void sendText(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) { return; }

            var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
            var player = playerObject.GetComponent<DefaultPlayer>();
            
            player.SendMessageServerRpc(message);
            input.text = string.Empty;  
        }

    }
}

