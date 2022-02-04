using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

namespace Server
{
    
    public class DefaultPlayer : NetworkBehaviour
    {
        /// <summary>
        /// NetworkVariable are used to sync value over the server
        /// Updating those variables let other clients and the server know about your local client state (position, rotation, or
        /// any custom data)
        /// Access rights to those variables can be changed during their declarations
        /// </summary>
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
        public NetworkVariable<Quaternion> Rotation = new NetworkVariable<Quaternion>();

        /// <summary>
        /// NetworkVariable to manage the online chat
        /// Messaged can be 20 character long as we use 20 variables to send 20 characters
        /// </summary>
        private NetworkVariable<char> mess_1 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_2 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_3 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_4 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_5 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_6 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_7 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_8 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_9 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_10 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_11 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_12 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_13 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_14 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_15 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_16 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_17 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_18 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_19 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_20 = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);
        private NetworkVariable<char> mess_end = new NetworkVariable<char>(NetworkVariableReadPermission.Everyone);

        //Chat object to print the content of the online chat to the local player
        public TMP_Text chat = null;

        //TODO: Implement the usage of the client Data (First/Last name, status so either guide or visitor,...)
        /// <summary>
        /// Keep track of the user informations
        /// </summary>
        private ClientData myData;

        /// <summary>
        /// NavmeshAgent of the local client
        /// It will allow us to move the client
        /// </summary>
        private NavMeshAgent localNavMeshAgent = null;

        /// <summary>
        /// Triggered when pressing the client button, a client player gameobject is instanciated and initialized
        /// following the content of this function
        /// </summary>
        public override void OnNetworkSpawn()
        {
            //TODO: Add details about user connection from the persistent gameobject of the Login scene
            if (IsOwner)
            {

                Debug.Log("New connection");

                //We add the chat gameobject to the current client gameobject
                GameObject tempchattext = null;
                tempchattext = GameObject.FindWithTag("ChatDisplayArea");
                chat = tempchattext.GetComponent<TMP_Text>();

                //We move the main camera to the client gameobject
                //We change its transform to change its parent for the current client gameobject
                Camera.main.transform.parent = gameObject.transform;
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.localRotation = Quaternion.identity;
                Camera.main.transform.localScale = Vector3.one;
                
                localNavMeshAgent = gameObject.AddComponent<NavMeshAgent>();
                if(localNavMeshAgent is null)
                {
                    Debug.Log("failed to create navmeshagent");
                }
                else
                {
                    Debug.Log("navmeshagent added");
                }
                
                //We find the old player object and disable it
                GameObject sceneplayer = GameObject.Find("Player");
                sceneplayer.SetActive(false);

                //Adding the script to control the player
                gameObject.AddComponent(typeof(PlayerController));
            }
            
        }

        /// <summary>
        /// Move the current player by a certain distance. Calls a Rpc method to apply the position change
        /// </summary>
        /// <param name="distance">Distance to apply</param>
        public void Move(Vector3 distance = default)
        {
            if (NetworkManager.Singleton.IsServer)
            {
                transform.position = distance;
                Position.Value = distance;
            }
            else
            {
                SubmitNewPlayerPositionServerRpc(distance);
            }
        }

        /// <summary>
        /// Rotate the current player by a certain angle. Calls a Rpc method to apply the rotation change
        /// </summary>
        /// <param name="rotation">Rotation to apply</param>
        public void Rotate(Quaternion rotation = default)
        {

            SubmitNewPlayerRotationServerRpc(rotation);

        }

        /// <summary>
        /// Change the value of the networkvariable Position to update the server with the new position of the current client.
        /// </summary>
        /// <param name="position">Position to update to</param>
        /// <param name="rpcParams">Rpc parameter to use (is defaulted)</param>
        [ServerRpc]
        void SubmitNewPlayerPositionServerRpc(Vector3 position, ServerRpcParams rpcParams = default)
        {
            Position.Value = position;
        }

        /// <summary>
        /// Change the value of the networkvariable Rotation to update the server with the new rotation of the current client.
        /// </summary>
        /// <param name="rotation">Rotation to update to</param>
        /// <param name="rpcParams">Rpc parameter to use</param>
        [ServerRpc]
        void SubmitNewPlayerRotationServerRpc(Quaternion rotation, ServerRpcParams rpcParams = default)
        {
            Rotation.Value = rotation;
        }

        /// <summary>
        /// Used to send the current position and rotation of the client to the server, preventing wrong initialization behaviors 
        /// </summary>
        /// <param name="rpcParams">RPCparams to use</param>
        [ServerRpc]
        void UpdatePositionRotationServerRpc(Vector3 position, Quaternion rotation, ServerRpcParams rpcParams = default)
        {
            Position.Value = position;
            Rotation.Value = rotation;
        }

        /// <summary>
        /// Send a message over the network. Each character of the message is stored in an individual networkvariable
        /// thus updating the serverwith the new message to broadcast
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="rpcParams">RPCparams to use</param>
        [ServerRpc]
        public void SendMessageServerRpc(string message, ServerRpcParams rpcParams = default)
        {
            Debug.Log("msg received");

            mess_1.Value = message[0];
            if(message.Length > 1) mess_2.Value = message[1];
            if (message.Length > 2) mess_3.Value = message[2];
            if (message.Length > 3) mess_4.Value = message[3];
            if (message.Length > 4) mess_5.Value = message[4];
            if (message.Length > 5) mess_6.Value = message[5];
            if (message.Length > 6) mess_7.Value = message[6];
            if (message.Length > 7) mess_8.Value = message[7];
            if (message.Length > 8) mess_9.Value = message[8];
            if (message.Length > 9) mess_10.Value = message[9];
            if (message.Length > 10) mess_11.Value = message[10];
            if (message.Length > 11) mess_12.Value = message[11];
            if (message.Length > 12) mess_13.Value = message[12];
            if (message.Length > 13) mess_14.Value = message[13];
            if (message.Length > 14) mess_15.Value = message[14];
            if (message.Length > 15) mess_16.Value = message[15];
            if (message.Length > 16) mess_17.Value = message[16];
            if (message.Length > 17) mess_18.Value = message[17];
            if (message.Length > 18) mess_19.Value = message[18];
            if (message.Length > 19) mess_20.Value = message[19];
            mess_end.Value = '\n';

        }

        //Built in unity function that is fired when a value is changed in the specified networkvariables
        //The callback functions specified for each networkvariable is called according to the change in the value
        private void OnEnable()
        {
            Position.OnValueChanged += OnPositionChanged;
            Rotation.OnValueChanged += OnRotationChanged;

            mess_1.OnValueChanged += onNewMessage;
            mess_2.OnValueChanged += onNewMessage;
            mess_3.OnValueChanged += onNewMessage;
            mess_4.OnValueChanged += onNewMessage;
            mess_5.OnValueChanged += onNewMessage;
            mess_6.OnValueChanged += onNewMessage;
            mess_7.OnValueChanged += onNewMessage;
            mess_8.OnValueChanged += onNewMessage;
            mess_9.OnValueChanged += onNewMessage;
            mess_10.OnValueChanged += onNewMessage;
            mess_11.OnValueChanged += onNewMessage;
            mess_12.OnValueChanged += onNewMessage;
            mess_13.OnValueChanged += onNewMessage;
            mess_14.OnValueChanged += onNewMessage;
            mess_15.OnValueChanged += onNewMessage;
            mess_16.OnValueChanged += onNewMessage;
            mess_17.OnValueChanged += onNewMessage;
            mess_18.OnValueChanged += onNewMessage;
            mess_19.OnValueChanged += onNewMessage;
            mess_20.OnValueChanged += onNewMessage;
            mess_end.OnValueChanged += onNewMessage;
        }

        //Built in unity function that is fired when a value is changed in the specified networkvariables
        //The callback functions specified for each networkvariable is called according to the change in the value
        private void OnDisable()
        {
            Position.OnValueChanged -= OnPositionChanged;
            Rotation.OnValueChanged -= OnRotationChanged;
        }

        /// <summary>
        /// Custom callback function to change the player position according to the new position received from the server
        /// </summary>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        private void OnPositionChanged(Vector3 oldPosition, Vector3 newPosition)
        {
            if(IsClient)
            {
                localNavMeshAgent.Move(newPosition);
            }
        }

        /// <summary>
        /// Custom callback function to change the player rotation according to the new position received from the server
        /// </summary>
        /// <param name="oldRotation"></param>
        /// <param name="newRotation"></param>
        private void OnRotationChanged(Quaternion oldRotation, Quaternion newRotation)
        {
            if (IsClient)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 1);
            }
        }

        /// <summary>
        /// Custom callback function to display the new message receive from the server on the screen
        /// </summary>
        /// <param name="oldMessage"></param>
        /// <param name="newMessage"></param>
        private void onNewMessage(char oldMessage, char newMessage)
        {
            if (!IsClient) { return; }
            if (chat is null)
                chat = GameObject.FindWithTag("ChatDisplayArea").GetComponent<TMP_Text>();
            Debug.Log("adding text "+newMessage);

            chat.text += newMessage;


        }
    }
}

