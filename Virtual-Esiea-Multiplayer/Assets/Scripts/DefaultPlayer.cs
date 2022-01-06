using Unity.Netcode;
using UnityEngine;
using TMPro;

namespace Server
{
    public class DefaultPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
        public TMP_Text chat = null;
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
        private ClientData myData;
        

        public override void OnNetworkSpawn()
        {
            //TODO: Add details about user connection
            Debug.Log("New connection");
            chat = FindObjectOfType<TMP_Text>();
            if (IsOwner)
            {
                
                Move();
            }
            
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                var randomPosition = GetRandomPositionOnPlane();
                transform.position = randomPosition;
                Position.Value = randomPosition;
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        void Update()
        {
            transform.position = Position.Value;
        }



        [ServerRpc]
        public void setServerRpc(string message, ServerRpcParams rpcParams = default)
        {
            Debug.Log("msg received");

            /*for (int i = 0; i < message.Length; i++)
            {
                mess_1.Value = message[i];
            }*/
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
            //chat.text += message;

        }
        private void OnEnable()
        {
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

        /*private void OnDisable()
        {
            chatMessages.OnValueChanged -= onNewMessage;
        }*/

        private void onNewMessage(char oldMessage, char newMessage)
        {
            if (!IsClient) { return; }

            Debug.Log("adding text "+newMessage);
            chat.text += newMessage;
        }
    }
}

